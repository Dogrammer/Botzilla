﻿using Botzilla.Domain.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Botzilla.Domain.DomainBaseClasses
{
    public class BaseEntity : ISoftDeletableEntity
    {
        public BaseEntity()
        {
            IsDeleted = false;
        }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? LastModified { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
    }
}
