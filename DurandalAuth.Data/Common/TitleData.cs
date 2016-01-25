using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

namespace DurandalAuth.Data.Common
{
    public class TitleData
    {
        public static string Mr = "Mr";

        public static string Mrs = "Mrs";

        public static string Dr = "Dr";

        public static void SetTitleData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.TitleLookups.Any())
            {
                return;
            }

            var mr = GetTitle(Mr);
            uow.TitleLookups.AddOrUpdate(mr);

            var mrs = GetTitle(Mrs);
            uow.TitleLookups.AddOrUpdate(mrs);

            hasChanges = true;
        }

        private static TitleLookup GetTitle(string addressType)
        {
            return new TitleLookup
            {
                Name = addressType,
                CreatedBy = SystemAdminData.Username,
                UpdatedBy = SystemAdminData.Username,
                CreatedDate = SystemAdminData.CreationDateTime,
                UpdatedDate = SystemAdminData.CreationDateTime
            };
        } 
    }
}