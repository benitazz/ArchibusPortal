#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class SecurityTrainingData
    {
        public static string CitName = "CIT";

        public static string VipName = "VIP";

        public static string K9Name = "K9";

        public static string FireArm = "FIREARM";

        public static string Other = "Other";

        public static void SetSecurityTrainingData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.SecurityTrainingLookups.Any())
            {
                return;
            }

            var cit = GetSecurityTrainingLookup(CitName);
            uow.SecurityTrainingLookups.AddOrUpdate(cit);

            var vip = GetSecurityTrainingLookup(VipName);
            uow.SecurityTrainingLookups.AddOrUpdate(vip);

            var k9 = GetSecurityTrainingLookup(K9Name);
            uow.SecurityTrainingLookups.AddOrUpdate(k9);

            var arm = GetSecurityTrainingLookup(FireArm);
            uow.SecurityTrainingLookups.AddOrUpdate(arm);

            var other = GetSecurityTrainingLookup(Other);
            uow.SecurityTrainingLookups.AddOrUpdate(other);

            hasChanges = true;
        }

        private static SecurityTrainingLookup GetSecurityTrainingLookup(string trainingType)
        {
            return new SecurityTrainingLookup
                       {
                           Name = trainingType,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}