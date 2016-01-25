#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public static class DecisionData
    {
        public static string YesDecision = "Yes";

        public static string NoDecision = "No";

        public static void SetYesNoLookupData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.YesNoLookups.Any())
            {
                return;
            }

            var yes = GetYesNoLookup(YesDecision);
            uow.YesNoLookups.AddOrUpdate(yes);

            var no = GetYesNoLookup(NoDecision);
            uow.YesNoLookups.AddOrUpdate(no);

            hasChanges = true;
        }

        private static YesNoLookup GetYesNoLookup(string decision)
        {
            return new YesNoLookup
                       {
                           Name = decision,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}