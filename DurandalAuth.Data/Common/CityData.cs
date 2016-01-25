#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class CityData
    {
        public static string Pretoria = "Pretoria";

        public static string Johanneburg = "Johannesburg";

        public static void SetCityNameData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
           /* if (uow.CityNameLookups.Any())
            {
                return;
            }

            var gauteng = uow.ProvinceLookups.First(p => p.Name == ProvinceData.Gauteng);

            var pretoria = GetCityNameLookup(gauteng, Pretoria);
            uow.CityNameLookups.AddOrUpdate(pretoria);

            var johanneburg = GetCityNameLookup(gauteng, Johanneburg);
            uow.CityNameLookups.AddOrUpdate(johanneburg);

            hasChanges = true;*/
        }

        private static CityNameLookup GetCityNameLookup(ProvinceLookup province, string cityName)
        {
            return new CityNameLookup
                       {
                           Name = cityName,
                           ProvinceLookup = province,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}