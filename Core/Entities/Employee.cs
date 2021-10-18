using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Employee : EntityBase
    {
        public string FullName { get; set; }
        public string HireDate { get; set; }
        public decimal Salary { get; set; }
        public UserRole role { get; set; }
    }
}