using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Stock : EntityBase
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Quantity { get; set; }
    }
}