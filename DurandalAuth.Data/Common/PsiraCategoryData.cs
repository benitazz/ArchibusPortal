using System.Data.Entity.Migrations;
using System.Linq;

using DurandalAuth.Domain.Model;

namespace DurandalAuth.Data.Common
{
    public class PsiraCategoryData
    {
        public static void SetPsiraCategoryLookup(DurandalAuthDbContext uow, ref bool hasChanges)
        {
            if (uow.PsiraStatusLookups.Any())
            {
                return;
            }

            var securityGuard = new PsiraCategoryLookup { Name = "Security Guard (Industrial and Commercial)" };
            uow.PsiraStatusLookups.AddOrUpdate(securityGuard);

            var cashInTransit = new PsiraCategoryLookup { Name = "Cash in Transit" };
            uow.PsiraStatusLookups.AddOrUpdate(cashInTransit);

            var bodyGuard = new PsiraCategoryLookup { Name = "Body Guarding" };
            uow.PsiraStatusLookups.AddOrUpdate(bodyGuard);

            var securityConsultant = new PsiraCategoryLookup { Name = "Security Consultant" };
            uow.PsiraStatusLookups.AddOrUpdate(securityConsultant);

            var reactionService = new PsiraCategoryLookup { Name = "Reaction Services" };
            uow.PsiraStatusLookups.AddOrUpdate(reactionService);

            var entertainmentVenueControl = new PsiraCategoryLookup { Name = "Entertainment / Venue Control" };
            uow.PsiraStatusLookups.AddOrUpdate(entertainmentVenueControl);

            var manufactureSecurity = new PsiraCategoryLookup { Name = "Manufacture Security Equipment" };
            uow.PsiraStatusLookups.AddOrUpdate(manufactureSecurity);

            var privateInvestigator = new PsiraCategoryLookup { Name = "Private Investigator" };
            uow.PsiraStatusLookups.AddOrUpdate(privateInvestigator);

            var training = new PsiraCategoryLookup { Name = "Training" };
            uow.PsiraStatusLookups.AddOrUpdate(training);

            var securityEquipmentInstaller = new PsiraCategoryLookup { Name = "Security Equipment Installer" };
            uow.PsiraStatusLookups.AddOrUpdate(securityEquipmentInstaller);

            var lockSmith = new PsiraCategoryLookup { Name = "Locksmith / Key Cutter" };
            uow.PsiraStatusLookups.AddOrUpdate(lockSmith);

            var securityRoomController = new PsiraCategoryLookup { Name = "Security Control Room" };
            uow.PsiraStatusLookups.AddOrUpdate(securityRoomController);

            var securityServices = new PsiraCategoryLookup { Name = "Rendering of Security Services" };
            uow.PsiraStatusLookups.AddOrUpdate(securityServices);

            var specialEvent = new PsiraCategoryLookup { Name = "Special Events" };
            uow.PsiraStatusLookups.AddOrUpdate(specialEvent);

            var carWatch = new PsiraCategoryLookup { Name = "Car Watch" };
            uow.PsiraStatusLookups.AddOrUpdate(carWatch);

            var other = new PsiraCategoryLookup { Name = "Other" };
            uow.PsiraStatusLookups.AddOrUpdate(other);

            var insurance = new PsiraCategoryLookup { Name = "Insurance" };
            uow.PsiraStatusLookups.AddOrUpdate(insurance);

            var securityandLossControl = new PsiraCategoryLookup { Name = "Security and Loss Control" };
            uow.PsiraStatusLookups.AddOrUpdate(securityandLossControl);

            var preventionAndDetection = new PsiraCategoryLookup { Name = "Fire prevention and detection" };
            uow.PsiraStatusLookups.AddOrUpdate(preventionAndDetection);

            var consultantEngineer = new PsiraCategoryLookup { Name = "Consulting Engineer" };
            uow.PsiraStatusLookups.AddOrUpdate(consultantEngineer);

            var dogTrainining = new PsiraCategoryLookup { Name = "Dog Training" };
            uow.PsiraStatusLookups.AddOrUpdate(dogTrainining);

            hasChanges = true;
        } 
    }
}