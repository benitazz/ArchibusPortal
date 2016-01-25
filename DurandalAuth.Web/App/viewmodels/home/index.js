define(['plugins/router', 'services/unitofwork'], function (router, unitofwork) {

    var unitofworkObj = unitofwork.create();

    return {

        profiles: ko.observableArray(),
        convertRouteToHash: router.convertRouteToHash,

        activate: function () {
            self = this;

            ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
            unitofworkObj.profiles.all().then(function (data) {
               self.profiles(data);
            });
        },

        search: function (data, event) {
            self: this;

            if (event.which == 13) {
                unitofworkObj.profile.find(
                    breeze.Predicate.create("firstName", "contains", event.target.value)
                     .or("lastName", "contains", event.target.value)
                     )
                    .then(function (d) {
                    debugger;
                    self.profiles(d);
                });
            }
            return true;
        }
    };
});