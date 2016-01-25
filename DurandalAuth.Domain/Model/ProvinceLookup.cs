using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class ProvinceLookup: AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DataMember]      
        public string Name { get; set; }
    }
}