#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class EntityTypeData
    {
        public static string Vendor = "Vendor";

        public static string Individual = "Individual";

        public static void SetEntityData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.EntityTypeLookups.Any())
            {
                return;
            }

            var vendor = GetEntityType(Vendor);
            uow.EntityTypeLookups.AddOrUpdate(vendor);

            var individual = GetEntityType(Individual);
            uow.EntityTypeLookups.AddOrUpdate(individual);

            hasChanges = true;
        }

        private static EntityTypeLookup GetEntityType(string decision)
        {
            return new EntityTypeLookup
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

