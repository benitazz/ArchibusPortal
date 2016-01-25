define(['services/unitofwork', 'services/logger', 'services/errorhandler'], function(unitofwork, logger, errorhandler) {
    var unitOfWork = unitofwork.create();

    var profileViewModel = {
        profile: ko.observable(),

        activate: function(queryString) {
            var id = queryString.id;
            self = this;
            unitOfWork.profiles.find(breeze.Predicate.create("userId", "==", id)).then(function(data) {
                self.profile(data[0]);
            });
        }
    };

    errorhandler.includeIn(profileViewModel);

    return profileViewModel;
});