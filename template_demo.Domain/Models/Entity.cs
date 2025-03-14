﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_verify.Model.Model
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public abstract class BaseEntity { }
    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }
    }

    public interface IAuditEntity
    {
        DateTime CreateDate { get; set; }
        string CreateUserId { get; set; }
        bool IsActive { get; set; }
        DateTime ModifyDate { get; set; }
        string ModifyUserId { get; set; }
        int StatusId { get; set; }
    }

    public abstract class AuditEntity<T> : Entity<T>, IAuditEntity
    {
        public DateTime CreateDate { get; set; }
        public string CreateUserId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime ModifyDate { get; set; }
        public string ModifyUserId { get; set; } = string.Empty;
        public int StatusId { get; set; }
    }
}
