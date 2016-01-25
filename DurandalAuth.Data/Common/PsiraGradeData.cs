#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class PsiraGradeData
    {
        public static string GradeA = "Grade A";

        public static string GradeB = "Grade B";

        public static string GradeC = "Grade C";

        public static string GradeD = "Grade D";

        public static string GradeE = "Grade E";

        public static string Other = "Other";

        public static void SetPsiraGradeData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.PsiraGradeLookups.Any())
            {
                return;
            }

            var gradeA = GetPsiraGradeLookup(GradeA);
            uow.PsiraGradeLookups.AddOrUpdate(gradeA);

            var gradeB = GetPsiraGradeLookup(GradeB);
            uow.PsiraGradeLookups.AddOrUpdate(gradeB);

            var gradeC = GetPsiraGradeLookup(GradeC);
            uow.PsiraGradeLookups.AddOrUpdate(gradeC);

            var gradeD = GetPsiraGradeLookup(GradeD);
            uow.PsiraGradeLookups.AddOrUpdate(gradeD);

            var gradeE = GetPsiraGradeLookup(GradeE);
            uow.PsiraGradeLookups.AddOrUpdate(gradeE);

            var other = GetPsiraGradeLookup(Other);
            uow.PsiraGradeLookups.AddOrUpdate(other);

            hasChanges = true;
        }

        private static PsiraGradeLookup GetPsiraGradeLookup(string grade)
        {
            return new PsiraGradeLookup
                       {
                           Name = grade,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}