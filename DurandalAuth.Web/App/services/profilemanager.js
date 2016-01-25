define(["durandal/system", "durandal/app", "plugins/router", "services/routeconfig", "services/utils", "services/logger"], function(system, app, router, routeconfig, utils, logger) {

    var self = this;

    return {

        /**
           * Register new user
           * param {object} data - Registration info
           */
        createuserprofile: function (userinfobject) {
            return $.ajax(routeconfig.createUserProfileUrl, {
                type: "POST",
                data: userinfobject,
                error: function (xhr, err) {
                    debugger;
                    alert(err);
                }
            });
        }
    };
});