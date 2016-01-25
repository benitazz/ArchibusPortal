#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class MaritalStatusData : AuditInfoComplete
    {
        public static string Married = "Married";

        public static string Single = "Single";

        public static string Divorced = "Divorced";

        public static string LivingTogether = "Living together With Partner";

        public static string Widow = "Widow";

        public static string Widower = "Widower";

        public static string Other = "Other";

        public static void SetMaritalStatusData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.MaritalStatusLookups.Any())
            {
                return;
            }

            var married = GetMaritalStatusLookup(Married);
            uow.MaritalStatusLookups.AddOrUpdate(married);

            var single = GetMaritalStatusLookup(Single);
            uow.MaritalStatusLookups.AddOrUpdate(single);

            var divorced = GetMaritalStatusLookup(Divorced);
            uow.MaritalStatusLookups.AddOrUpdate(divorced);

            var livingTogether = GetMaritalStatusLookup(LivingTogether);
            uow.MaritalStatusLookups.AddOrUpdate(livingTogether);

            var widow = GetMaritalStatusLookup(Widow);
            uow.MaritalStatusLookups.AddOrUpdate(widow);

            var widower = GetMaritalStatusLookup(Widower);
            uow.MaritalStatusLookups.AddOrUpdate(widower);

            var other = GetMaritalStatusLookup(Other);
            uow.MaritalStatusLookups.AddOrUpdate(other);

            hasChanges = true;
        }

        private static MaritalStatusLookup GetMaritalStatusLookup(string maritalStatus)
        {
            return new MaritalStatusLookup
                       {
                           Name = maritalStatus,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}