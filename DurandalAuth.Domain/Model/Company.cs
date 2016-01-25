#region

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class Company : AuditInfoComplete
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string RegisteredName { get; set; }

        [DataMember]
        public string RegistrationNumber { get; set; }
    }
}