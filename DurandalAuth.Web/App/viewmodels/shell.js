﻿define(['plugins/router', 'services/appsecurity', 'services/errorhandler', 'services/entitymanagerprovider', 'model/modelBuilder',  'services/custombindinghandlers'],
    function (router, appsecurity, errorhandler, entitymanagerprovider, modelBuilder) {

    entitymanagerprovider.modelBuilder = modelBuilder.extendMetadata;

    var viewmodel = {

        attached : function() {
            $(document).find("footer").show();
        },

        activate: function () {
            var self = this;            

            return entitymanagerprovider
                    .prepare()
                    .then(function() {
                       
                        //configure routing
                        router.makeRelative({ moduleId: 'viewmodels' });

                        // If the route has the authorize flag and the user is not logged in => navigate to login view      
                        // If the route has the confirmed flag and the user's email is not confirmed => navigate to login view and display confirmation warning
                        router.guardRoute = function (instance, instruction) {
                            if (sessionStorage["redirectTo"]) {
                                var redirectTo = sessionStorage["redirectTo"]
                                sessionStorage.removeItem("redirectTo");
                                return redirectTo;
                            }

                            if (instruction.config.authorize) {
                                if (typeof (appsecurity.userInfo()) !== 'undefined') {
                                    if (appsecurity.isUserInRole(instruction.config.authorize)) {
                                        if (instruction.config.confirmed) {
                                            if (appsecurity.userInfo().isEmailConfirmed()) {
                                                return true;
                                            } else {
                                                appsecurity.showConfirmationWarning(true);
                                                return "/account/login?returnUrl=" + encodeURIComponent(instruction.fragment);
                                            }
                                        } else {
                                            return true;
                                        }
                                    } else {
                                        return "/account/login?returnUrl=" + encodeURIComponent(instruction.fragment);
                                    }
                                } else {
                                    return "/account/login?returnUrl=" + encodeURIComponent(instruction.fragment);
                                }
                            } else {
                                return true;
                            }
                        };
						
                        // Config Routes
                        // Routes with authorize flag will be forbidden and will redirect to login page
                        // As this is javascript and is controlled by the user and his browser, the flag is only a UI guidance. You should always check again on 
                        // server in order to ensure the resources travelling back on the wire are really allowed

                        return router.map([
                            // Nav urls
                            { route: ['','home/index'],                       moduleId: 'home/index',                        title: 'Home',                        nav: true, hash : "#home/index"    },
                            //{ route: 'home/search', moduleId: 'home/search', title: 'Search', nav: true, hash: "#home/search" },
                            { route: 'home/about', moduleId: 'home/about', title: 'About', nav: true, hash: "#home/about" },
                            { route: 'home/contact', moduleId: 'home/contact', title: 'Contact', nav: true, hash: "#home/contact" },
                            { route: 'home/help',                             moduleId: 'home/help',                         title: 'Help',                        nav: true, hash : "#home/help" },
                         
                            { route: 'notfound',                              moduleId: 'notfound',                          title: 'Not found',                   nav: false },
                                
                            // Admin panel url
                            { route: 'admin/panel',                           moduleId: 'admin/panel',                       title: 'Admin Panel',                 nav: false, hash : "#admin/panel",  authorize: ["Administrator"] } ,

                            // Account Controller urls
                            { route: 'account/login',                         moduleId: 'account/login',                     title: 'Login',                       nav: false, hash : "#account/login" },
                            { route: 'account/externalloginconfirmation',     moduleId: 'account/externalloginconfirmation', title: 'External login confirmation', nav: false, hash : "#account/externalloginconfirmation" },
                            { route: 'account/externalloginfailure',          moduleId: 'account/externalloginfailure',      title: 'External login failure',      nav: false, hash : "#account/externalloginfailure" },
                            { route: 'account/register',                      moduleId: 'account/register',                  title: 'Register',                    nav: false, hash : "#account/register" },
                            { route: 'account/manage',                        moduleId: 'account/manage',                    title: 'Manage account',              nav: false, hash:  "#account/manage", authorize: ["User", "Administrator"] },
                            { route: 'account/registrationcomplete',          moduleId: 'account/registrationcomplete',      title: 'Registration complete',       nav: false, hash:  "#account/registrationcomplete" },
                            { route: 'account/forgotpassword',                moduleId: 'account/forgotpassword',            title: 'Forgot password',             nav: false, hash:  "#account/forgotpassword" },
                            { route: 'account/resetpassword', moduleId: 'account/resetpassword', title: 'Reset password', nav: false, hash: "#account/resetpassword" },
                            { route: 'user/editProfile', moduleId: 'user/editProfile', title: 'Edit Profile', nav: false, hash: "#user/editProfile" },
                            { route: 'profile', moduleId: 'user/profile', title: 'Public Profile', nav: false, hash: "#user/profile" },

                            // User articles urls
                            { route: 'user/dashboard',                        moduleId: 'user/dashboard',                    title: 'Dashboard',                   nav: false, hash : "#user/dashboard",  authorize: ["User"], confirmed : true  },
                            { route: ':createdby/:categorycode/:articlecode', moduleId: 'user/article',                      title: 'Article',                     nav: false },
                        ])
                        .buildNavigationModel()
                        .mapUnknownRoutes("notfound","notfound")
                        .activate({ pushState : true });
                    })
                    .fail(self.handlevalidationerrors);
        }
    };

    errorhandler.includeIn(viewmodel);

    return viewmodel;
});
