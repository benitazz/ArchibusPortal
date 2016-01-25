#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class CityNameLookup: AuditInfoComplete
    { 
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [DataMember]
        public int ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        [DataMember]
        public ProvinceLookup ProvinceLookup { get; set; }
    }
}