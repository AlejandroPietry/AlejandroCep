using System;

namespace Domain.Models
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
