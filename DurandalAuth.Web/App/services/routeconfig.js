﻿/** 
 * @module Route table
 */
define(function () {

    var routes = {
        // Breeze Routes. Relative to entitymanagerprovider service name
        lookupUrl: "durandalauth/lookups",
        saveChangesUrl: "durandalauth/savechanges",
        publicArticlesUrl: "durandalauth/publicarticles",
        privateArticlesUrl: "durandalauth/privatearticles",
        categoriesUrl: "durandalauth/categories",
        titlesUrl: "durandalauth/TitleLookups",
        addressTypesUrl: "durandalauth/AddressTypeLookups",
        provincesUrl: "durandalauth/ProvinceLookups",
        decisionLookupUrl: "durandalauth/YesNoLookups",
        //cityNameUrl: "durandalauth/CityNameLookups",
        ethnicityNamesUrl: "durandalauth/EthnicityLookups",
        nationalityNamesUrl: "durandalauth/NationalityLookups",
        maritalStatusNamesUrl: "durandalauth/MaritalStatusLookups",
        entityTypeNamesUrl: "durandalauth/EntityTypeLookup",
        profilesUrl: "durandalauth/profiles",
        profileUrl: "durandalauth/getprofile",
		
		//Authentication Routes
        addExternalLoginUrl : "/api/account/addexternallogin",
        changePasswordUrl : "/api/account/changepassword",
        loginUrl : "/token",
        logoutUrl : "/api/account/logout",
        registerUrl: "/api/account/register",
        createUserProfileUrl: "/api/profile/createuserprofile",
        registerExternalUrl : "/api/account/registerexternal",
        removeLoginUrl : "/api/account/removelogin",
        setPasswordUrl: "/api/account/setpassword",
        siteUrl : "/",
        userInfoUrl: "/api/account/userinfo",
        getUsersUrl: "/api/account/getusers",
        forgotPassword: "/api/account/forgotpassword",
        resendMailRoute: "/api/account/resendconfirmationemail",
        resetPassword: "/api/account/resetpassword",
        deleteaccount: "/api/account/deleteaccount"
    };

    return routes;

});