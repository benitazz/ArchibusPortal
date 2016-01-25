#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class PsiraGradeLookup: AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(10)]
        [Required]
        public string Name { get; set; }
    }
}