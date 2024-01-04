using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Identity;

namespace IDrobeAPI.Domain.Entities
{
    public class Order : EntityBase,ISoftDeleteAble
    {
        public Order()
        {
            
        }

        public Order(DateTime orderDate, decimal totalAmount, string userId) : this()
        {
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            UserId = userId;
        }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Relation
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }

}
