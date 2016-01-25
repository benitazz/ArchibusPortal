define(['services/appsecurity',
        'plugins/router',
        'services/errorhandler',
        'services/profilemanager',
        'services/logger',
        'services/constant',
        'services/unitofwork'],
    function (appsecurity, router, errorhandler, userprofile, logger, constant, unitofwork) {
        var unitOfWork = unitofwork.create();

        var addressLine1 = ko.observable();
        var addressLine2 = ko.observable();
        var addressLine3 = ko.observable();
        var addressLine4 = ko.observable();
        var selectedProvince = ko.observable();
        var selectedSuburb = ko.observable();
        var postalCode = ko.observable();
        var availableAddressTypes = ko.observableArray();
        var availableProvinces = ko.observableArray();
        var availableSuburbs = ko.observableArray();
        var addressType = ko.observable();
        var city = ko.observable();
        var isEdit = ko.observable(true);
        var isDefault = ko.observable(false);
        var provinceText = ko.observable();
        var suburbText = ko.observable();
        var typedSuburbName = ko.observable();
        var isNewDefault = ko.observable();
        var addressTitle = ko.observable(constant.individualAddressTitle);
        //var canEdit = currentCustomer.canEdit;

        var addressInfoViewModel = {
            addressLine1: addressLine1,
            addressLine2: addressLine2,
            addressLine3: addressLine3,
            addressLine4: addressLine4,
            selectedProvince: selectedProvince,
            selectedSuburb : selectedSuburb,
            provinceText: provinceText,
            suburbText: suburbText,
            postalCode: postalCode,
            availableAddressTypes: availableAddressTypes,
            availableProvinces: availableProvinces,
            availableSuburbs: availableSuburbs,
            addressType: addressType,
            typedSuburbName: typedSuburbName,
            isNewDefault: isNewDefault,
            city: city,
            isEdit: isEdit,
            isDefault: isDefault,
            addressTitle: addressTitle,

            activate: function () {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
                self = this;

               unitOfWork.addresstypelookups.all().then(function (data) {
                   self.availableAddressTypes(data);

                   //set the selected to the first on the list
                   self.addressType(data[0]);
                });

               unitOfWork.provincelookups.all().then(function (data) {
                    self.availableProvinces(data);
               });

               /* debugger;
                unitOfWork.addresstypelookups.find(breeze.Predicate.create("name", "==", "Physical Address")).then(function (data) {
                    debugger;
                   self.addressType(data[0]);
               });*/
            },

            addressObject: function() {
                self = this;

                return {
                    AddressTypeId: self.addressType() ? self.addressType().id(): 0,
                    AddressLine1: self.addressLine1(),
                    AddressLine2: self.addressLine2(),
                    Suburb: self.suburbText(),
                    ProvinceId: self.selectedProvince() ? self.selectedProvince().id() : 0,
                    PostalCode: self.postalCode
                }
            }

        }

        errorhandler.includeIn(addressInfoViewModel);

        addressInfoViewModel["errors"] = ko.validation.group(addressInfoViewModel);

        return addressInfoViewModel;
    });