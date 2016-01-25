#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public static class EthnicityData
    {
        public static string African = "African";

        public static string Coloured = "Coloured";

        public static string Indian = "Indian";

        public static string White = "White";

        public static string Chinese = "Chinese";

        public static string Other = "Other";

        public static void SetEthnicityData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.EthnicityLookups.Any())
            {
                return;
            }

            var african = GetEthnicityLookup(African);
            uow.EthnicityLookups.AddOrUpdate(african);

            var coloured = GetEthnicityLookup(Coloured);
            uow.EthnicityLookups.AddOrUpdate(coloured);

            var white = GetEthnicityLookup(White);
            uow.EthnicityLookups.AddOrUpdate(white);

            var indian = GetEthnicityLookup(Indian);
            uow.EthnicityLookups.AddOrUpdate(indian);

            var chinese = GetEthnicityLookup(Chinese);
            uow.EthnicityLookups.AddOrUpdate(chinese);

            var other = GetEthnicityLookup(Other);
            uow.EthnicityLookups.AddOrUpdate(other);

            hasChanges = true;
        }

        private static EthnicityLookup GetEthnicityLookup(string ethniCity)
        {
            return new EthnicityLookup
                       {
                           Name = ethniCity,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}