using System;
using System.Collections.Generic;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Payment: EntityBase
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        
        public decimal TotalPayment { get; set; }
    }
}