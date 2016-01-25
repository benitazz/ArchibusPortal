define(['services/appsecurity', 'plugins/router', 'services/errorhandler', 'services/profilemanager', 'services/logger'],
    function (appsecurity, router, errorhandler, userprofile, logger, userInfoVm, contactInfoVm) {
        var firstname = ko.observable("").extend({ required: true });
        var surname = ko.observable("").extend({ required: true });
        var cellphone = ko.observable();
        var workphone = ko.observable();
        var faxnumber = ko.observable();
        var email = ko.observable();

        var serviceProviderContactPersonViewModel = {
            firstname: firstname,
            surname: surname,
            cellPhone: cellphone,
            workPhone: workphone,
            faxNumber: faxnumber,
            email: email,
            
            activate: function () {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
            }
        }

        errorhandler.includeIn(serviceProviderContactPersonViewModel);

        serviceProviderContactPersonViewModel["errors"] = ko.validation.group(serviceProviderContactPersonViewModel);

        return serviceProviderContactPersonViewModel;
    });