#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public static class ProvinceData
    {
        //Province Names
        public static string Gauteng = "Gauteng";

        public static string NorthWest = "North West";

        public static string Mpumalanga = "Mpumalanga";

        public static string KwaZuluNatal = "KwaZulu-Natal";

        public static string Freestate = "Free State";

        public static string WesternCape = "Western Cape";

        public static string EasternCape = "Eastern Cape";

        public static string NorthernCape = "Northern Cape";

        public static string Limpopo = "Limpopo";

        public static void SetProvinceData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.ProvinceLookups.Any())
            {
                return;
            }

            var gauteng = GetProvinceLookup(Gauteng);
            uow.ProvinceLookups.AddOrUpdate(gauteng);

            var mpumalanga = GetProvinceLookup(Mpumalanga);
            uow.ProvinceLookups.AddOrUpdate(mpumalanga);

            var freestate = GetProvinceLookup(Freestate);
            uow.ProvinceLookups.AddOrUpdate(freestate);

            var northWest = GetProvinceLookup(NorthWest);
            uow.ProvinceLookups.AddOrUpdate(northWest);

            var westernCape = GetProvinceLookup(WesternCape);
            uow.ProvinceLookups.AddOrUpdate(westernCape);

            var easternCape = GetProvinceLookup(EasternCape);
            uow.ProvinceLookups.AddOrUpdate(easternCape);

            var limpopo = GetProvinceLookup(Limpopo);
            uow.ProvinceLookups.AddOrUpdate(limpopo);

            var kzn = GetProvinceLookup(KwaZuluNatal);
            uow.ProvinceLookups.AddOrUpdate(kzn);

            var northernCape = GetProvinceLookup(NorthernCape);
            uow.ProvinceLookups.AddOrUpdate(northernCape);

            hasChanges = true;
        }

        private static ProvinceLookup GetProvinceLookup(string province)
        {
            return new ProvinceLookup
                       {
                           Name = province,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}