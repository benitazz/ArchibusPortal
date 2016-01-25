#region

using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Web.Helpers
{
    public class LookupBundle
    {
        public IQueryable<Category> Categories { get; set; }

        public IQueryable<TitleLookup> TitleLookups { get; set; }

        public IQueryable<NationalityLookup> NationalityLookups { get; set; }

        public IQueryable<ProvinceLookup> ProvinceLookups { get; set; }

        //public IQueryable<CityNameLookup> CityNameLookups { get; set; }

        public IQueryable<AddressLookup> AddressTypeLookups { get; set; }

        public IQueryable<MaritalStatusLookup> MaritalStatusLookups { get; set; }

        public IQueryable<YesNoLookup> YesNoLookups { get; set; }

        public IQueryable<EntityTypeLookup> EntityTypeLookups { get; set; }

        public IQueryable<EthnicityLookup> EthnicityLookups { get; set; }
    }
}