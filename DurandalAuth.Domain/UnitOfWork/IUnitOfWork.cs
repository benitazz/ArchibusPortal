#region

using Breeze.ContextProvider;

using DurandalAuth.Domain.Model;
using DurandalAuth.Domain.Repositories;

using Newtonsoft.Json.Linq;

#endregion

namespace DurandalAuth.Domain.UnitOfWork
{
    /// <summary>
    ///     Contract for the UnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        IRepository<Article> ArticleRepository { get; }

        IRepository<Category> CategoryRepository { get; }

        IRepository<Tag> TagRepository { get; }

        IRepository<UserProfile> UserProfileRepository { get; }

        IRepository<Profile> ProfileRepository { get; }

        IRepository<Address> AddressRepository { get; }

        IRepository<Contact> ContactRepository { get; }

        IRepository<ProvinceLookup> ProvinceRepository { get; }

        //IRepository<CityNameLookup> CityRepository { get; }

        IRepository<EthnicityLookup> EthnicityRepository { get; }

        IRepository<GenderLookup> GenderRepository { get; }

        IRepository<PsiraGradeLookup> PsiraGradeRepository { get; }

        IRepository<PsiraCategoryLookup> PsiraCategoryRepository { get; }

        IRepository<SecurityTrainingLookup> SecurityTrainingRepository { get; }

        IRepository<EmploymentStatusLookup> EmploymentStatusRepository { get; }

        IRepository<NationalityLookup> NationalityRepository { get; }

        IRepository<LanguageLookup> LanguangeRepository { get; }

        IRepository<YesNoLookup> YesNoRepository { get; }

        IRepository<MaritalStatusLookup> MaritalStatusRepository { get; }

        IRepository<AddressLookup> AddressLookupRepository { get; }

        IRepository<EntityTypeLookup> EntityLookupRepository { get; }

        IRepository<TitleLookup> TitleLookupRepository { get; }

        IRepository<Individual> IndividualRepository { get; }

        IRepository<Company> CompanyRepository { get; }

        /*IRepository<em> EmRepository { get; }

        IRepository<bl> BlRepository { get; }

        IRepository<rm> RmRepository { get; }

        IRepository<fl> FlRepository { get; }*/
        
        void Commit();

        //Breeze specific
        string Metadata();

        SaveResult Commit(JObject changeSet);
    }
}