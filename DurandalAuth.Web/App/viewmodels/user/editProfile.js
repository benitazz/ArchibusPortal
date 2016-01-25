define(['services/unitofwork', 'services/logger', 'services/errorhandler'], function (unitofwork, logger, errorhandler) {
    var unitOfWork = unitofwork.create();

    var editProfileViewModel = {

        profile: ko.observable(),

        activate: function () {


        },

        attached: function () {
            self = this;

            unitOfWork.profile.all().then(function (p) {
                debugger;
                if (p && p.length > 0) {
                    self.profile(p[0]);
                }

            });
        },

        saveProfile: function () {

            if (!unitOfWork.hasChanges()) {
                return;
            }

            // console.log("test");
            unitOfWork.commit().then(function () {
                logger.logSuccess("Profile was saved", null, null, true);
            })
                .fail(this.handleError);
        },

        clearButton: function () {
            unitOfWork.rollback();
        }
    };

    errorhandler.includeIn(editProfileViewModel);

    return editProfileViewModel;
});