define(['services/appsecurity',
        'plugins/router',
        'services/errorhandler',
        'services/profilemanager',
        'services/logger',
        'services/constant'],
    function (appsecurity, router, errorhandler, userprofile, logger, constant) {
        var cellphone = ko.observable();
        var homephone = ko.observable();
        var workphone = ko.observable();
        var faxnumber = ko.observable();
        var email = ko.observable();
        var website = ko.observable();
        var isEdit = ko.observable(true);
        var isDefault = ko.observable(false);
        var contactTitle = ko.observable(constant.individualContactTitle);
        //var canEdit = currentCustomer.canEdit;

        var contactInfoViewModel = {
            cellPhone: cellphone,
            homePhone: homephone,
            workPhone: workphone,
            faxNumber: faxnumber,
            contactTitle: contactTitle,
            email: email,
            isEdit: isEdit,
            isDefault: isDefault,
            website : website,

            activate: function() {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
            },

            contactObject: function() {
                self = this;

                return {
                    CellPhone: self.cellPhone(),
                    HomePhone: self.homePhone(),
                    WorkPhone: self.workPhone(),
                    FaxNumber: self.faxNumber(),
                    Email: self.email(),
                    Website: self.website()
                }
            }
        }

        errorhandler.includeIn(contactInfoViewModel);

        contactInfoViewModel["errors"] = ko.validation.group(contactInfoViewModel);

        return contactInfoViewModel;
    });