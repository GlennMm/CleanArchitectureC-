using System;

namespace Core.Entities.Base
{
    public class EntityBase
    {
        public Int64 Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}