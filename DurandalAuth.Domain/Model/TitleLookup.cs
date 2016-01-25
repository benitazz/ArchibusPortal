using System.Runtime.Serialization;

namespace DurandalAuth.Domain.Model
{
    public class TitleLookup : AuditInfoComplete
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}