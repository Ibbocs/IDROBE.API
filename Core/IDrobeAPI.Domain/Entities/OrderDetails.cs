using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class OrderDetails : EntityBase,ISoftDeleteAble
    {
        public OrderDetails()
        {
            
        }

        public OrderDetails(int quantity, decimal subtotal, int orderId, int productId) : this()
        {
            Quantity = quantity;
            Subtotal = subtotal;
            OrderId = orderId;
            ProductId = productId;
        }

        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }

        // Relation
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

}
