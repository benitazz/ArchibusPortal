#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class Profile : AuditInfoComplete
    {
        [Key, DataMember]
        public int ProfileId { get; set; }

        [DataMember]
        public int? AddressId { get; set; }

        [DataMember]
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        [ForeignKey("Contact")]
        public int? ContanctId { get; set; }

        [DataMember]
        public Contact Contact { get; set; }

        [DataMember]
        public int? EntityTypeId { get; set; }

        [DataMember]
        [ForeignKey("EntityTypeId")]
        public EntityTypeLookup EntityTypeLookup { get; set; }

        [DataMember]
        public int? IndividualId { get; set; }

        [DataMember]
        [ForeignKey("IndividualId")]
        public Individual Individual { get; set; }

        [DataMember]
        public int? CompanyId { get; set; }

        [DataMember]
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        [DataMember]
        [ForeignKey("UserId")]
        public UserProfile UserProfile { get; set; }
    }
}