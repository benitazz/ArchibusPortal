/** 
  * @module Manage registering users
  * @requires appsecurity
  * @requires router
  * @requires errorHandler
*/

define(['services/appsecurity',
    'plugins/router',
    'services/errorhandler',
    'viewmodels/controls/userInfo',
    'viewmodels/controls/addressInfo',
    'viewmodels/controls/contactInfo',
    'viewmodels/controls/serviceproviderinfo',
     'services/constant'],
    function (appsecurity, router, errorhandler, userInfoVm, addressInfoVm, contactInfoVm, serviceproviderVm, constant) {

        var username = ko.observable().extend({ required: true }),
            email = ko.observable().extend({ required: true, email: true }),
            password = ko.observable().extend({ required: true, minLength: 6 }),
            confirmpassword = ko.observable().extend({ required: true, minLength: 6, equal: password }),
            userInfoViewModel = ko.observable(userInfoVm),
            addressInfoViewModel = ko.observable(addressInfoVm),
            serviceProviderViewModel = ko.observable(serviceproviderVm),
            contactInfoViewModel = ko.observable(contactInfoVm);

        var viewmodel = {

            username: username,

            email: email,

            password: password,

            confirmpassword: confirmpassword,

            userInfoViewModel: userInfoViewModel,

            addressInfoViewModel: addressInfoViewModel,

            contactInfoViewModel: contactInfoViewModel,

            serviceProviderViewModel: serviceProviderViewModel,

            isVendorVisible: ko.observable(false),

            activate: function (isvendor) {

                ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });

                self = this;

                if (isvendor && isvendor.isvendor === "1") {
                    self.isVendorVisible(true);
                    self.contactInfoViewModel().contactTitle(constant.serviceproviderContactTitle());
                    self.addressInfoViewModel().addressTitle(constant.serviceproviderAddressTitle());
                } else {
                    self.isVendorVisible(false);
                    self.contactInfoViewModel().contactTitle(constant.individualContactTitle);
                    self.addressInfoViewModel().addressTitle(constant.individualAddressTitle);
                }
            },

            register: function () {
                var self = this;

                if (this.errors().length !== 0) {
                    this.errors.showAllMessages();
                    return;
                }

                appsecurity.register({
                    userName: self.username(),
                    eMail: self.email(),
                    password: self.password(),
                    confirmPassword: self.confirmpassword()
                }).done(function (userid) {
                    //create user profile

                    if (self.isVendorVisible()) {
                        self.serviceProviderViewModel().createuserprofile(userid, self.addressInfoViewModel().addressObject(), self.contactInfoViewModel().contactObject());
                    } else {
                        self.userInfoViewModel().createuserprofile(userid, self.addressInfoViewModel().addressObject(), self.contactInfoViewModel().contactObject());
                    }
                    
                    appsecurity.login({
                        grant_type: "password",
                        username: self.username(),
                        password: self.password()
                    }).done(function (data) {
                        if (data.userName && data.access_token) {
                            appsecurity.setAuthInfo(
								data.userName,
								data.roles,
                                false,
								data.access_token,
								self.rememberMe);
                            self.username("");
                            self.email("");
                            self.password("");
                            self.confirmpassword("");
                            self.errors.showAllMessages(false);
                        }
                        router.navigate("account/manage");
                    }).fail(self.handleauthenticationerrors);
                }).fail(self.handlevalidationerrors);
            }
        }

        errorhandler.includeIn(viewmodel);

        viewmodel["errors"] = ko.validation.group(viewmodel);

        return viewmodel;
    });