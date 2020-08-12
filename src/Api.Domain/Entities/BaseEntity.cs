using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid id { get; set; }
        private DateTime? _createdAt;
        public DateTime? createdAt
        {
            get => _createdAt;
            set => _createdAt = value ?? DateTime.UtcNow;
        }
        private DateTime? _updatedAt;
        public DateTime? updatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value ?? DateTime.UtcNow;
        }

    }
}
