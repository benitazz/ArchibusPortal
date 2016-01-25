#region

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using DurandalAuth.Data.Migrations;
using DurandalAuth.Domain.Model;
using DurandalAuth.Domain.Model.Mapping;

using Microsoft.AspNet.Identity.EntityFramework;

#endregion

namespace DurandalAuth.Data
{
    public class DurandalAuthDbContext : IdentityDbContext<UserProfile>
    {
        public DurandalAuthDbContext()
            : base("DurandalAuthConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DurandalAuthDbContext, Configuration>());
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ProvinceLookup> ProvinceLookups { get; set; }

        //public DbSet<CityNameLookup> CityNameLookups { get; set; }

        public DbSet<NationalityLookup> NationalityLookups { get; set; }

        public DbSet<PsiraGradeLookup> PsiraGradeLookups { get; set; }

        public DbSet<PsiraCategoryLookup> PsiraStatusLookups { get; set; }

        public DbSet<SecurityTrainingLookup> SecurityTrainingLookups { get; set; }

        public DbSet<EthnicityLookup> EthnicityLookups { get; set; }

        public DbSet<GenderLookup> GenderLookups { get; set; }

        public DbSet<EmploymentStatusLookup> EmploymentStatusLookups { get; set; }

        public DbSet<LanguageLookup> LanguageLookups { get; set; }

        public DbSet<YesNoLookup> YesNoLookups { get; set; }

        public DbSet<MaritalStatusLookup> MaritalStatusLookups { get; set; }

        public DbSet<AddressLookup> AddressLookups { get; set; }

        public DbSet<EntityTypeLookup> EntityTypeLookups { get; set; }

        public DbSet<TitleLookup> TitleLookups { get; set; }

        public DbSet<Individual> Individuals { get; set; }

        public DbSet<Company> Companies { get; set; }

        //public DbSet<em> Ems { get; set; }

       /* public DbSet<bl> Bls { get; set; }

        public DbSet<fl> Fls { get; set; }

        public DbSet<rm> Rms { get; set; }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Configurations.Add(new emMap());

            // Very bad idea not doing this :)
            //http://stackoverflow.com/questions/19474662/map-tables-using-fluent-api-in-asp-net-mvc5-ef6
            base.OnModelCreating(modelBuilder);
        }
    }
}