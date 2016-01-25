#region

using System.Runtime.Serialization;

using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace DurandalAuth.Domain.Model
{
    /// <summary>
    ///     User Profile entity
    /// </summary>
    [DataContract(IsReference = true)]
    public class UserProfile : IdentityUser
    {
        
    }
}