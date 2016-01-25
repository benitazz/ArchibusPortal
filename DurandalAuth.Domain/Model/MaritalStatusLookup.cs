using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class MaritalStatusLookup : AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
    }
}