using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class Address : AuditInfoComplete
    {
        [DataMember]
        [Key]
        public int AddressId { get; set; }

        [DataMember]
        public int AddressTypeId { get; set; }

        [DataMember]
        [ForeignKey("AddressTypeId")]
        public AddressLookup AddressLookup { get; set; }

        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string Suburb { get; set; }

        /*[DataMember]
        public int AddressCityId { get; set; }

        [DataMember]
        [ForeignKey("AddressCityId")]
        public CityNameLookup CityNameLookup { get; set; }*/

        [DataMember]
        public int ProvinceId { get; set; }

        [DataMember]
        [ForeignKey("ProvinceId")]
        public ProvinceLookup ProvinceLookup { get; set; }

        [DataMember]
        [StringLength(20)]
        public string PostalCode { get; set; }
    }
}