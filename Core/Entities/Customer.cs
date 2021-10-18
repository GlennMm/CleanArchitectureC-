using Core.Entities.Base;

namespace Core.Entities
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public decimal Limit { get; set; }
        public decimal OverDraftLimit { get; set; }
    }
}