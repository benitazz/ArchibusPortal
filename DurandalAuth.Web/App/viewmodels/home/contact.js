define(['plugins/router'], function (router) {

    return {
       activate: function () {
            ga('send', 'pageview', { 'page': window.location.href, 'title': document.title });
        }
    };
});