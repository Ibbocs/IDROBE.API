using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class ProductCategory : IEntityBaseAble
    {
        //productun birden cox categorysi ola biler. Messelen bir komp hem komp hem de electronics kategorisinde ola biler
        public ProductCategory()
        {
                
        }

        public ProductCategory(int productId, int categoryId) : this()
        {
            ProductId = productId;
            CategoryId = categoryId;
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
    }

}
