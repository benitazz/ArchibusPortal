using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class Contact : AuditInfoComplete
    {
        [Key]
        [DataMember]
        public int ContactId { get; set; }

        [DataMember]
        public string CellPhone { get; set; }

        [DataMember]
        public string HomePhone { get; set; }

        [DataMember]
        public string WorkPhone { get; set; }

        [DataMember]
        public string FaxNumber { get; set; }

        [DataMember]
        public string Email { get; set; }
        
        [DataMember]
        public string Website { get; set; }
    }
}