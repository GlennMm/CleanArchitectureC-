using System.Collections;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Invoice : EntityBase
    {
        public string FullyPaid { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}