﻿#region

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

#endregion

namespace DurandalAuth.Domain.Model
{
    /// <summary>
    ///     Audit info for the different Entities
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class AuditInfoBase
    {
        /// <summary>
        ///     ConcurrencyCheck
        /// </summary>
        [DataMember]
        [ConcurrencyCheck]
        public int RowVersion { get; internal set; }
    }

    /// <summary>
    ///     Audit info for the different Entities
    /// </summary>
    [DataContract(IsReference = true)]
    public abstract class AuditInfoComplete : AuditInfoBase
    {
        /// <summary>
        ///     Date the entity was created
        /// </summary>
        [DataMember]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Date the entity was updated
        /// </summary>
        [DataMember]
        public DateTime UpdatedDate { get; set; }

        /// <summary>L
        ///     User creating the entity
        /// </summary>
        [DataMember]
        public string CreatedBy { get; set; }

        /// <summary>
        ///     User updating the entity
        /// </summary>
        [DataMember]
        public string UpdatedBy { get; set; }
    }
}