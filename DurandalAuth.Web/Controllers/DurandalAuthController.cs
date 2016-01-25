#region

using System.Linq;
using System.Net;
using System.Web.Http;

using Breeze.ContextProvider;
using Breeze.WebApi2;

using DurandalAuth.Domain.Model;
using DurandalAuth.Domain.UnitOfWork;
using DurandalAuth.Web.Helpers;

using Microsoft.AspNet.Identity;

using Newtonsoft.Json.Linq;

#endregion

namespace DurandalAuth.Web.Controllers
{
    /// <summary>
    ///     Main controller retrieving information from the data store
    /// </summary>
    [BreezeController]
    public class DurandalAuthController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DurandalAuthController(IUnitOfWork uow)
        {
            this._unitOfWork = uow;
        }

        /// <summary>
        ///     Get private articles
        /// </summary>
        /// <returns>IQueryable articles</returns>
        [HttpGet]
        [Authorize(Roles = "User")]
        public IQueryable<Article> PrivateArticles()
        {
            if (this.User.IsInRole("User"))
            {
                return this._unitOfWork.ArticleRepository.Find(a => a.CreatedBy == this.User.Identity.Name);
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        /// <summary>
        ///     Get public articles
        /// </summary>
        /// <returns>IQueryable articles</returns>
        [HttpGet]
        [AllowAnonymous]
        public IQueryable<Article> PublicArticles()
        {
            return this._unitOfWork.ArticleRepository.Find(a => a.IsPublished);
        }

        /// <summary>
        ///     Save changes to data store
        /// </summary>
        /// <param name="saveBundle">The changes</param>
        /// <returns>Save result</returns>
        [HttpPost]
        [AllowAnonymous]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return this._unitOfWork.Commit(saveBundle);
        }

        /// <summary>
        ///     Get the lookups on client first app load
        /// </summary>
        /// <returns>The bundles</returns>
        [HttpGet]
        [AllowAnonymous]
        public LookupBundle Lookups()
        {
          return new LookupBundle
                       {
                           Categories = this._unitOfWork.CategoryRepository.All(),
                           TitleLookups =
                               this._unitOfWork.TitleLookupRepository.All().OrderBy(title => title.Name),
                          MaritalStatusLookups =
                               this._unitOfWork.MaritalStatusRepository.All()
                               .OrderBy(maritalStatus => maritalStatus.Name),
                           EntityTypeLookups = this._unitOfWork.EntityLookupRepository.All(),
                           NationalityLookups =
                               this._unitOfWork.NationalityRepository.All()
                               .OrderBy(nationality => nationality.Name),
                           AddressTypeLookups =
                               this._unitOfWork.AddressLookupRepository.All()
                               .OrderBy(addressType => addressType.Name),
                           ProvinceLookups =
                               this._unitOfWork.ProvinceRepository.All().OrderBy(province => province.Name),
                           YesNoLookups = this._unitOfWork.YesNoRepository.All(),
                           //CityNameLookups = this._unitOfWork.CityRepository.All().OrderBy(city => city.Name),
                           EthnicityLookups =
                               this._unitOfWork.EthnicityRepository.All()
                               .OrderBy(ethnicity => ethnicity.Name)
                       };
        }

        [HttpGet]
        [AllowAnonymous]
        public Profile GetProfile()
        {
            var userId = this.User.Identity.GetUserId();
            var profile = this._unitOfWork.ProfileRepository.FirstOrDefault(a => a.UserId == userId);
            return profile;
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<Profile> Profiles()
        {
            return this._unitOfWork.ProfileRepository.All();
        }
    }
}