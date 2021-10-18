using Core.Entities.Base;

namespace Core.Entities
{
    public class Sale : EntityBase
    {
        public decimal Pride { get; set; }
        public string Quantity { get; set; }
        public bool Paid { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}