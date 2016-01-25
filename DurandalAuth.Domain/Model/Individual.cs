#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    public class Individual : AuditInfoComplete
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Surname { get; set; }

        /* [DataMember]
         public string IdNumber { get; set; }

         [DataMember]
         public string Passport { get; set; }*/

        [DataMember]
        public DateTime BirthDate { get; set; }

        [DataMember]
        [ForeignKey("GenderLookup")]
        public int? GenderLookupId { get; set; }

        [DataMember]
        public GenderLookup GenderLookup { get; set; }
    }
}