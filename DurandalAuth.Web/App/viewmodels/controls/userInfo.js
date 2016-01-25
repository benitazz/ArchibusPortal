define(['services/appsecurity', 'plugins/router', 'services/errorhandler', 'services/profilemanager', 'services/logger', 'services/unitofwork'],
    function (appsecurity, router, errorhandler, userprofile, logger, unitofwork) {

        /*//jQuery.noConflict();
        ko.bindingHandlers.datepicker = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                //initialize datepicker with some optional options
                var options = allBindingsAccessor().datepickerOptions || {};
                $(element).datepicker(options);

                //handle the field changing
                ko.utils.registerEventHandler(element, "change", function () {
                    var observable = valueAccessor();
                    observable($(element).datepicker("getDate"));
                });

                //handle disposal (if KO removes by the template binding)
                ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                    $(element).datepicker("destroy");
                });

            },
            update: function (element, valueAccessor) {
                var value = ko.utils.unwrapObservable(valueAccessor()),
                    current = $(element).datepicker("getDate");

                if (value - current !== 0) {
                    $(element).datepicker("setDate", value);
                }
            }
        };*/



        //ko.bindingHandlers.datepicker = {
        //    init: function (element, valueAccessor, allBindingsAccessor) {

        //        var unwrap = ko.utils.unwrapObservable;
        //        var dataSource = valueAccessor();
        //        var binding = allBindingsAccessor();

        //        //initialize datepicker with some optional options
        //        var options = allBindingsAccessor().datepickerOptions || {};
        //        $(element).datepicker(options);
        //        $(element).datepicker('update', dataSource());
        //        //when a user changes the date, update the view model
        //        ko.utils.registerEventHandler(element, "changeDate", function (event) {
        //            var value = valueAccessor();
        //            if (ko.isObservable(value)) {
        //                value(event.date);
        //            }
        //        });
        //    },
        //    update: function (element, valueAccessor) {
        //        var widget = $(element).data("datepicker");

        //        var value = ko.utils.unwrapObservable(valueAccessor());

        //        //when the view model is updated, update the widget
        //        if (widget) {
        //            widget.date = value;
        //            if (widget.date) {
        //                widget.setValue();
        //                $(element).datepicker('update', value);
        //            }
        //        }
        //    }
        //};

        var userdetailViewModel = function () {

            var self = this;
            self.firstname = ko.observable("").extend({ required: true });
            self.surname = ko.observable("").extend({ required: true });
            self.nationalities = ko.observableArray();
            self.nationality = ko.observable();
            self.initials = ko.observable("").extend({ required: true });
            //self.dateOfBirth = ko.observable(new Date("2014-01-10"));
            self.dateOfBirth = ko.observable("");
            self.gender = ko.observable(true);
            self.isEdit = ko.observable(true);
            self.titles = ko.observableArray();
            self.title = ko.observable();
            self.startDate = ko.observable(null);

            self.unitofwork = unitofwork.create();
            //this.IsMale = ko.observable(true);

            //this.gender.ForEditing2 = ko.computed({
            //    read: function () {
            //        debugger;
            //        return self.gender().toString();
            //    },
            //    write: function (newValue) {
            //        debugger;
            //        self.gender(newValue === "true");
            //    },
            //    owner: this
            //});


            //this.IsMale.ForEditing = ko.computed({
            //    read: function () {
            //        debugger;
            //        return self.IsMale().toString();
            //    },
            //    write: function (newValue) {
            //        debugger;
            //        self.IsMale(newValue === "true");
            //    },
            //    owner: this
            //});

            self.activate = function () {
                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });

                self.unitofwork.titles.all().then(function (data) {
                    self.titles(data);
                });

                self.unitofwork.nationalitylookups.all().then(function (data) {
                    self.nationalities(data);
                });
            };

            self.createuserprofile = function (userid, addressObject, contactObject) {

                if (this.errors().length !== 0) {
                    this.errors.showAllMessages();
                    return false;
                }

                self.profileObject = {};
                self.profileObject["Individual"] = self.userInfoObject();
                self.profileObject["UserId"] = userid;
                self.profileObject["Address"] = addressObject;
                self.profileObject["Contact"] = contactObject;
                userprofile.createuserprofile(self.profileObject).fail(self.handlevalidationerrors);
                return true;
            };

            self.userInfoObject = function() {
                self = this;

                return {
                    FirstName: self.firstname(),
                    Surname: self.surname(),
                    GenderLookupId: self.gender() === "Male" ? 1 : 2
                }
            };
        }

        var userInfoViewModel = new userdetailViewModel();

        errorhandler.includeIn(userInfoViewModel);

        userInfoViewModel["errors"] = ko.validation.group(userInfoViewModel);

        return userInfoViewModel;
    });