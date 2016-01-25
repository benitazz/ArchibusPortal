define(['services/appsecurity', 'plugins/router', 'services/errorhandler', 'services/profilemanager', 'services/logger', 'services/unitofwork'],
    function (appsecurity, router, errorhandler, userprofile, logger, unitofwork) {

        var serviceProviderViewModel = function () {

            var self = this;
            self.firstname = ko.observable("");

            self.unitofwork = unitofwork.create();

            self.activate = function () {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
            };

        }

        var spViewModel = new serviceProviderViewModel();

        errorhandler.includeIn(spViewModel);

        spViewModel["errors"] = ko.validation.group(spViewModel);

        return spViewModel;
    });