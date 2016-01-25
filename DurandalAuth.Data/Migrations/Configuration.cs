#region

using System;
using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Data.Common;
using DurandalAuth.Domain.Model;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace DurandalAuth.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DurandalAuthDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DurandalAuthDbContext context)
        {
            var userManager = new UserManager<UserProfile>(new UserStore<UserProfile>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }

            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }

            if (userManager.FindByName("admin") == null)
            {
                var user = new UserProfile { UserName = "admin", Email = "admin@mydomain.com", EmailConfirmed = true };
                var result = userManager.Create(user, "admin1234");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }
            }

            var uow = new DurandalAuthDbContext();

            var hasChanges = false;

            SetCategoryData(uow);
            ProvinceData.SetProvinceData(uow , ref hasChanges);
            GenderData.SetGenderData(uow, ref hasChanges);
            EthnicityData.SetEthnicityData(uow, ref hasChanges);
            LanguageData.SetLanguageData(uow, ref hasChanges);
            EmploymentData.SetEmploymentStatus(uow, ref hasChanges);
            PsiraGradeData.SetPsiraGradeData(uow, ref hasChanges);
            SecurityTrainingData.SetSecurityTrainingData(uow, ref hasChanges);
            DecisionData.SetYesNoLookupData(uow, ref hasChanges);
            PsiraCategoryData.SetPsiraCategoryLookup(uow, ref hasChanges);
            //CityData.SetCityNameData(uow, ref hasChanges);
            AddressData.SetAddressData(uow, ref hasChanges);
            MaritalStatusData.SetMaritalStatusData(uow, ref hasChanges);
            EntityTypeData.SetEntityData(uow, ref hasChanges);
            TitleData.SetTitleData(uow, ref hasChanges);
            
            if (hasChanges)
            {
                uow.SaveChanges();
            }
        }

        private static bool SetCategoryData(DurandalAuthDbContext uow)
        {
            if (uow.Categories.Any())
            {
                return true;
            }

            var category1 = new Category { CategoryId = Guid.NewGuid(), Name = "Grade D" };
            category1.SetUrlReference();
            uow.Categories.AddOrUpdate(category1);

            var category2 = new Category { CategoryId = Guid.NewGuid(), Name = "General" };
            category2.SetUrlReference();
            uow.Categories.AddOrUpdate(category2);

            var category3 = new Category { CategoryId = Guid.NewGuid(), Name = "Grade A" };
            category3.SetUrlReference();
            uow.Categories.AddOrUpdate(category3);

            var category4 = new Category { CategoryId = Guid.NewGuid(), Name = "Grade B" };
            category4.SetUrlReference();
            uow.Categories.AddOrUpdate(category4);

            var category5 = new Category { CategoryId = Guid.NewGuid(), Name = "Grade C" };
            category5.SetUrlReference();
            uow.Categories.AddOrUpdate(category5);
            return false;
        }
    }
}