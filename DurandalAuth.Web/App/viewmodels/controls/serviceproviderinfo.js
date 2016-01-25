define(['services/appsecurity',
        'plugins/router',
        'services/errorhandler',
        'services/profilemanager',
        'services/logger',
        'viewmodels/controls/serviceproviderepresentative'],
    function (appsecurity,
              router,
              errorhandler,
              userprofile,
              logger,
              serviceproviderRepresentativeVm) {
        var registeredname = ko.observable();
        var tradingname = ko.observable();
        var registrationnumber = ko.observable();
        var serviceproviderrepresentativeviewmodel = ko.observable(serviceproviderRepresentativeVm);

        var serviceproviderViewModel = {
            RegisteredName: registeredname,
            TradingName: tradingname,
            RegistrationNumber: registrationnumber,
            serviceproviderrepresentativeviewmodel: serviceproviderrepresentativeviewmodel,

            activate: function() {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });

            },

            createuserprofile: function(userid, addressObject, contactObject) {
               self = this;
                if (this.errors().length !== 0) {
                    this.errors.showAllMessages();
                    return false;
                }

                self.profileObject = {};
                self.profileObject["Company"] = self.companyObject();
                self.profileObject["UserId"] = userid;
                self.profileObject["Address"] = addressObject;
                self.profileObject["Contact"] = contactObject;

                userprofile.createuserprofile(self.profileObject).fail(self.handlevalidationerrors);
               return true;
            },

            companyObject : function () {
                self = this;

                return {
                    RegisteredName: self.RegisteredName(),
                    CompanyName: self.TradingName(),
                    RegistrationNumber: self.RegistrationNumber()
                }
            }
        }

        errorhandler.includeIn(serviceproviderViewModel);

        serviceproviderViewModel["errors"] = ko.validation.group(serviceproviderViewModel);

        return serviceproviderViewModel;
    });
