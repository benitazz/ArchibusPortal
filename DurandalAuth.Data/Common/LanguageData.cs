#region

using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

#endregion

namespace DurandalAuth.Data.Common
{
    public class LanguageData
    {
        public static string English = "English";

        public static string Afrikaans = "Afrikaans";

        public static string Zulu = "Zulu";

        public static string Ndebele = "Ndebele";

        public static string Xhosa = "Xhosa";

        public static string Tswana = "Tswana";

        public static string Sotho = "Sotho";

        public static string NothernSotho = "Nothern Sotho";

        public static string Swati = "Swati";

        public static string Tsonga = "Tsonga";

        public static string Venda = "Venda";

        public static string Other = "Other";

        public static void SetLanguageData(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.LanguageLookups.Any())
            {
                return;
            }

            var english = GetLanguageLookup(English);
            uow.LanguageLookups.AddOrUpdate(english);

            var afrikaans = GetLanguageLookup(Afrikaans);
            uow.LanguageLookups.AddOrUpdate(afrikaans);

            var tswana = GetLanguageLookup(Tswana);
            uow.LanguageLookups.AddOrUpdate(tswana);

            var northenSotho = GetLanguageLookup(NothernSotho);
            uow.LanguageLookups.AddOrUpdate(northenSotho);

            var sotho = GetLanguageLookup(Sotho);
            uow.LanguageLookups.AddOrUpdate(sotho);

            var tsonga = GetLanguageLookup(Tsonga);
            uow.LanguageLookups.AddOrUpdate(tsonga);

            var venda = GetLanguageLookup(Venda);
            uow.LanguageLookups.AddOrUpdate(venda);

            var swati = GetLanguageLookup(Swati);
            uow.LanguageLookups.AddOrUpdate(swati);

            var ndebele = GetLanguageLookup(Ndebele);
            uow.LanguageLookups.AddOrUpdate(ndebele);

            var xhosa = GetLanguageLookup(Xhosa);
            uow.LanguageLookups.AddOrUpdate(xhosa);

            var zulu = GetLanguageLookup(Zulu);
            uow.LanguageLookups.AddOrUpdate(zulu);

            var other = GetLanguageLookup(Other);
            uow.LanguageLookups.AddOrUpdate(other);

            hasChanges = true;
        }

        private static LanguageLookup GetLanguageLookup(string language)
        {
            return new LanguageLookup
                       {
                           Name = language,
                           CreatedBy = SystemAdminData.Username,
                           UpdatedBy = SystemAdminData.Username,
                           CreatedDate = SystemAdminData.CreationDateTime,
                           UpdatedDate = SystemAdminData.CreationDateTime
                       };
        }
    }
}