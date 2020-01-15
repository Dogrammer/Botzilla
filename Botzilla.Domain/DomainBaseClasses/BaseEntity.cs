using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.DomainBaseClasses
{
    public class BaseEntity : ICreationAuditedEntity, IModificationAuditedEntity, IDeletionAuditedEntity, ISoftDeletableEntity, IAmFullyAudited, ITrackable
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedByUserName { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public int? ModifiedBy { get; set; }

        [NotMapped]
        public TrackingState TrackingState { get; set; }

        [NotMapped]
        public ICollection<string> ModifiedProperties { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
