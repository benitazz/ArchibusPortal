#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class AddressData
    {
        public static string PhysicalAddress = "Physical Address";

        public static string PostalAddress = "Postal Address";

        public static void SetAddressData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.AddressLookups.Any())
            {
                return;
            }

            var physicalAddress = GetAddress(PhysicalAddress);
            uow.AddressLookups.AddOrUpdate(physicalAddress);

            var postalAddress = GetAddress(PostalAddress);
            uow.AddressLookups.AddOrUpdate(postalAddress);

            hasChanges = true;
        }

        private static AddressLookup GetAddress(string addressType)
        {
            return new AddressLookup
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