#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public static class GenderData
    {
        public static string Male = "Male";

        public static string Female = "Female";

        public static void SetGenderData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.GenderLookups.Any())
            {
                return;
            }

            var male = GetGenderLookup(Male);
            uow.GenderLookups.AddOrUpdate(male);

            var female = GetGenderLookup(Female);
            uow.GenderLookups.AddOrUpdate(female);

            hasChanges = true;
        }

        private static GenderLookup GetGenderLookup(string gender)
        {
            return new GenderLookup
                       {
                           Name = gender,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}