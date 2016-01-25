using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class EthnicityLookup: AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
    }
}