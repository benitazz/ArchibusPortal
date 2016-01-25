#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class EmploymentData
    {
        public static string PermanentEmployement = "Permanet Employed";

        public static string TemporaryEmployed = "Temporary Employed";

        public static string Unemployed = "Unemployed";

        public static void SetEmploymentStatus(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.EmploymentStatusLookups.Any())
            {
                return;
            }

            var permanent = GetEmploymentData(PermanentEmployement);
            uow.EmploymentStatusLookups.AddOrUpdate(permanent);

            var temporary = GetEmploymentData(TemporaryEmployed);
            uow.EmploymentStatusLookups.AddOrUpdate(temporary);

            var unemployed = GetEmploymentData(Unemployed);
            uow.EmploymentStatusLookups.AddOrUpdate(unemployed);

            hasChanges = true;
        }

        private static EmploymentStatusLookup GetEmploymentData(string employerType)
        {
            return new EmploymentStatusLookup
                       {
                           Name = employerType,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}