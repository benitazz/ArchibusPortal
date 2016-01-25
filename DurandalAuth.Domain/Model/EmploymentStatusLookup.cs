#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class EmploymentStatusLookup: AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
}