#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using DurandalAuth.Domain.Model;
using DurandalAuth.Domain.UnitOfWork;
using DurandalAuth.Web.Helpers;
using DurandalAuth.Web.Models;
using DurandalAuth.Web.Providers;
using DurandalAuth.Web.Results;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;

#endregion

namespace DurandalAuth.Web.Controllers
{
    /// <summary>
    ///     Authentication controller implementing two oAuth flows
    ///     1. Resource owner password grant for users with local accounts
    ///     2. Implicit grant for authenticating with social providers
    /// </summary>
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private const string LocalLoginProvider = "Local";

        private ApplicationUserManager _usermanager;

        /// <summary>
        ///     ctor
        /// </summary>
        public AccountController(IUnitOfWork unitofwork, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            this.UnitOfwork = unitofwork;
            this.AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return this._usermanager
                       ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                this._usermanager = value;
            }
        }

        private IUnitOfWork UnitOfwork { get; set; }

        private ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; set; }

        /// <summary>
        ///     Get user info
        ///     401 if not authenticated
        /// </summary>
        /// <returns>The user info</returns>
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public async Task<UserInfoViewModel> GetUserInfo()
        {
            var externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            var userIdentity = this.User.Identity as ClaimsIdentity;

            // Get roles from the user claims
            // We are setting the claims in the AuthenticationOAuthProvider properties
            var roles = new List<string>();

            if (userIdentity != null)
            {
                userIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).ForEach(claim => roles.Add(claim.Value));
            }

            //Check for Email confirmed
            var emailConfirmed = externalLogin != null
                                 || await this.UserManager.IsEmailConfirmedAsync(this.User.Identity.GetUserId());

            return new UserInfoViewModel
                       {
                           UserName = this.User.Identity.GetUserName(),
                           IsEmailConfirmed = emailConfirmed,
                           HasRegistered = externalLogin == null,
                           LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null,
                           Roles = roles
                       };
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("ConfirmEmail", Name = "ConfirmEmail")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                this.ModelState.AddModelError("error", "You need to provide your user id and confirmation code");
                return this.BadRequest(this.ModelState);
            }

            var result = await this.UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                return this.Redirect(this.Url.Content("~/account/registrationcomplete"));
            }

            var errorResult = this.GetErrorResult(result);
            return errorResult;
        }

        [HttpPost]
        [Route("ResendConfirmationEmail", Name = "ResendConfirmationEmail")]
        public async Task<IHttpActionResult> ResendConfirmationEmail()
        {
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());
            var code = await this.UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = this.Url.Link("ConfirmEmail", new { userId = user.Id, code });

            var notification = new AccountNotificationModel
                                   {
                                       Code = code,
                                       Url = callbackUrl,
                                       UserId = user.Id,
                                       Email = user.Email,
                                       DisplayName = user.UserName
                                   };

            var body = ViewRenderer.RenderView("~/Views/Mailer/NewAccount.cshtml", notification);
            await this.UserManager.SendEmailAsync(user.Id, "Home service account confirmation", body);

            return this.Ok();
        }

        [HttpPost]
        [Route("DeleteAccount")]
        public async Task<IHttpActionResult> DeleteAccount()
        {
            var user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());

            if (user == null)
            {
                return this.BadRequest();
            }

            var result = await this.UserManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        ///     If the user forget the password this action will send him a reset password mail
        /// </summary>
        /// <param name="model">The forgot password model</param>
        /// <returns>IHttpActionResult</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IHttpActionResult> ForgotPassword(ForgotPasswordBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await this.UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    this.ModelState.AddModelError("", "The user either does not exist or is not confirmed.");
                    return this.BadRequest(this.ModelState);
                }

                var code = await this.UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = this.Url.Content("~/account/resetpassword?email=")
                                  + HttpUtility.UrlEncode(model.Email) + "&code=" + HttpUtility.UrlEncode(code);

                var notification = new AccountNotificationModel { Url = callbackUrl, DisplayName = user.UserName };

                var body = ViewRenderer.RenderView("~/Views/Mailer/PasswordReset.cshtml", notification);
                await this.UserManager.SendEmailAsync(user.Id, "DurandalAuth reset password", body);

                return this.Ok();
            }

            // If we got this far, something failed
            return this.BadRequest(this.ModelState);
        }

        /// <summary>
        ///     Reset the user password
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("ResetPassword", Name = "ResetPassword")]
        public async Task<IHttpActionResult> ResetPassword(ResetPasswordBindingModel model)
        {
            if (this.ModelState.IsValid)
            {
                var user = await this.UserManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    this.ModelState.AddModelError("", "No user found.");
                    return this.BadRequest(this.ModelState);
                }
                var result = await this.UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return this.Ok();
                }
                var errorResult = this.GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }
            }

            // If we got this far, something failed
            return this.BadRequest(this.ModelState);
        }

        /// <summary>
        ///     Logout
        /// </summary>
        /// <returns>Http 200 Result</returns>
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            this.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return this.Ok();
        }

        /// <summary>
        ///     Get the info for managing user accounts
        /// </summary>
        /// <param name="returnUrl">The return url</param>
        /// <param name="generateState">generate a random state for being stored and compared on the client and avoid CSRF attacks</param>
        /// <returns>The manage info</returns>
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            if (!this.IsLocalUrl(returnUrl))
            {
                this.ModelState.AddModelError("returnUrl", "Can´t redirect to external urls");
                throw new HttpResponseException(
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState));
            }

            IdentityUser user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            var logins = new List<UserLoginInfoViewModel>();

            foreach (var linkedAccount in user.Logins)
            {
                logins.Add(
                    new UserLoginInfoViewModel
                        {
                            LoginProvider = linkedAccount.LoginProvider,
                            ProviderKey = linkedAccount.ProviderKey
                        });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(
                    new UserLoginInfoViewModel { LoginProvider = LocalLoginProvider, ProviderKey = user.UserName });
            }

            return new ManageInfoViewModel
                       {
                           LocalLoginProvider = LocalLoginProvider,
                           UserName = user.UserName,
                           Logins = logins,
                           ExternalLoginProviders = this.GetExternalLogins(returnUrl, generateState)
                       };
        }

        /// <summary>
        ///     Change user password
        /// </summary>
        /// <param name="model">Change password model</param>
        /// <returns>Http 400 or 200</returns>
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            // Cannot change passwords for test users
            // Remove following lines for real usage
            if (this.User.IsInRole("Administrator") || this.User.Identity.GetUserName() == "user")
            {
                this.ModelState.AddModelError(
                    "Unable to change the password",
                    "Cannot change the admin password in this demo app. Remove lines in ChangePassword (AccountController) action for real usage");
                return this.BadRequest(this.ModelState);
            }

            var result =
                await
                this.UserManager.ChangePasswordAsync(
                    this.User.Identity.GetUserId(),
                    model.OldPassword,
                    model.NewPassword);
            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        ///     Set user password
        /// </summary>
        /// <param name="model">Set user password model</param>
        /// <returns>Http 400 or 200</returns>
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);
            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        ///     Add a new external login to the user account
        /// </summary>
        /// <param name="model">External login model</param>
        /// <returns>Http 400 or 200</returns>
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var ticket = this.AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null
                || (ticket.Properties != null && ticket.Properties.ExpiresUtc.HasValue
                    && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return this.BadRequest("Failed to login to the external provider.");
            }

            var externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return this.BadRequest("This external login is already associated with an account.");
            }

            var result =
                await
                this.UserManager.AddLoginAsync(
                    this.User.Identity.GetUserId(),
                    new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        ///     Remove login from user account
        /// </summary>
        /// <param name="model">Remove login model</param>
        /// <returns>Http 400 or 200</returns>
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await this.UserManager.RemovePasswordAsync(this.User.Identity.GetUserId());
            }
            else
            {
                result =
                    await
                    this.UserManager.RemoveLoginAsync(
                        this.User.Identity.GetUserId(),
                        new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            var errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        ///     Try to create a new external login
        ///     This is the external login endpoint and will be reached when the oAuth provider system return control to this app
        /// </summary>
        /// <param name="provider">The external provider</param>
        /// <param name="error">If any error happened</param>
        /// <returns>Http 400 or 200</returns>
        [OverrideAuthentication] // Suppress Global authentication filters like bearer token host auth
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return this.Redirect(this.Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            var externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return this.InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            var user =
                await
                this.UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            var hasRegistered = user != null;

            if (hasRegistered)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var oAuthIdentity = await this.UserManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
                var cookieIdentity =
                    await this.UserManager.CreateIdentityAsync(user, CookieAuthenticationDefaults.AuthenticationType);

                var justCreatedIdentity = await this.UserManager.FindByNameAsync(user.UserName);
                var roles = await this.UserManager.GetRolesAsync(justCreatedIdentity.Id);

                var properties = ApplicationOAuthProvider.CreateProperties(user.UserName, roles.ToArray(), true);
                this.Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                this.Authentication.SignIn(identity);
            }

            return this.Ok();
        }

        /// <summary>
        ///     Get all external logins
        /// </summary>
        /// <param name="returnUrl">The return url</param>
        /// <param name="generateState">generate a random state for being stored and compared on the client and avoid CSRF attacks</param>
        /// <returns>External logins list</returns>
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            if (!this.IsLocalUrl(returnUrl))
            {
                this.ModelState.AddModelError("returnUrl", "Can´t redirect to external urls");
                throw new HttpResponseException(
                    this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, this.ModelState));
            }

            var descriptions = this.Authentication.GetExternalAuthenticationTypes();
            var logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (var description in descriptions)
            {
                var login = new ExternalLoginViewModel
                                {
                                    Name = description.Caption,
                                    Url =
                                        this.Url.Route(
                                            "ExternalLogin",
                                            new
                                                {
                                                    provider = description.AuthenticationType,
                                                    response_type = "token",
                                                    client_id = Startup.PublicClientId,
                                                    redirect_uri =
                                        new Uri(this.Request.RequestUri, returnUrl).AbsoluteUri,
                                                    state
                                                }),
                                    State = state
                                };
                logins.Add(login);
            }

            return logins;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = new UserProfile { UserName = model.UserName, Email = model.Email, EmailConfirmed = false };
           
            var identityResult = await this.UserManager.CreateAsync(user, model.Password);

            var createResult = this.GetErrorResult(identityResult);

            if (createResult != null)
            {
                return createResult;
            }

            var justCreatedUser = await this.UserManager.FindByNameAsync(model.UserName);

            /*var profile = new Profile
                              {
                                  UserId = justCreatedUser.Id
                              };*/

           var roleResult = await this.UserManager.AddToRoleAsync(justCreatedUser.Id, "User");

            var addRoleResult = this.GetErrorResult(roleResult);

            if (addRoleResult != null)
            {
                return addRoleResult;
            }

            var code = await this.UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            var callbackUrl = this.Url.Link("ConfirmEmail", new { userId = user.Id, code });

            var notification = new AccountNotificationModel
                                   {
                                       Code = code,
                                       Url = callbackUrl,
                                       UserId = justCreatedUser.Id,
                                       Email = justCreatedUser.Email,
                                       DisplayName = justCreatedUser.UserName
                                   };

            var body = ViewRenderer.RenderView("~/Views/Mailer/NewAccount.cshtml", notification);
            await this.UserManager.SendEmailAsync(user.Id, "Home Service account confirmation", body);

            //return this.Created(this.Request.RequestUri + justCreatedUser.Id, profile);

            return this.Ok(justCreatedUser.Id);
        }

        // POST api/Account/RegisterExternal
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return this.InternalServerError();
            }

            var user = new UserProfile { UserName = model.UserName, Email = model.Email, EmailConfirmed = true };

            user.Logins.Add(
                new IdentityUserLogin
                    {
                        LoginProvider = externalLogin.LoginProvider,
                        ProviderKey = externalLogin.ProviderKey,
                        UserId = user.Id
                    });

            var identityResult = await this.UserManager.CreateAsync(user);

            var createResult = this.GetErrorResult(identityResult);

            if (createResult != null)
            {
                return createResult;
            }

            var justCreatedUser = await this.UserManager.FindByNameAsync(model.UserName);

            var roleResult = await this.UserManager.AddToRoleAsync(justCreatedUser.Id, "User");

            var addRoleResult = this.GetErrorResult(roleResult);

            if (addRoleResult != null)
            {
                return addRoleResult;
            }

            return this.Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IEnumerable<UserProfileViewModel> GetUsers()
        {
            var users = this.UnitOfwork.UserProfileRepository.All();
            return users.Select(user => new UserProfileViewModel { UserName = user.UserName }).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.UserManager != null)
                {
                    this.UserManager.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares

        private IAuthenticationManager Authentication
        {
            get
            {
                return this.Request.GetOwinContext().Authentication;
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        this.ModelState.AddModelError("", error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    // No errors in ModelState, return empty BadRequest
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }

            public string ProviderKey { get; set; }

            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, this.ProviderKey, null, this.LoginProvider));

                if (this.UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, this.UserName, null, this.LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                var providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                           {
                               LoginProvider = providerKeyClaim.Issuer,
                               ProviderKey = providerKeyClaim.Value,
                               UserName = identity.FindFirstValue(ClaimTypes.Name)
                           };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static readonly RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits should be divisible by 8.", "strengthInBits");
                }

                var strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        private bool IsLocalUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            Uri absoluteUri;
            if (Uri.TryCreate(url, UriKind.Absolute, out absoluteUri))
            {
                return String.Equals(this.Request.RequestUri.Host, absoluteUri.Host, StringComparison.OrdinalIgnoreCase);
            }
            var isLocal = !url.StartsWith("http:", StringComparison.OrdinalIgnoreCase)
                          && !url.StartsWith("https:", StringComparison.OrdinalIgnoreCase)
                          && Uri.IsWellFormedUriString(url, UriKind.Relative);
            return isLocal;
        }

        #endregion
    }
}