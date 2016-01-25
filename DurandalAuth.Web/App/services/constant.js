/** 
 * @module Route table
 */
define(function () {

    var constant = {
        serviceprovider: "Service Provider",
        individualContactTitle: "Contact Details",
        serviceproviderContactTitle: function(){return this.serviceprovider + " " + this.individualContactTitle},
        individualAddressTitle: "Address Details",
        serviceproviderAddressTitle: function () { return this.serviceprovider + " " + this.individualAddressTitle }
    };

    return constant;

});