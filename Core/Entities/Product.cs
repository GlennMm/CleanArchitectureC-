using System;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public bool Available { get; set; }
        public decimal Price { get; set; }
        public int ReOrderQuantity { get; set; }
        public int LowQuantity { get; set; }
    }
}