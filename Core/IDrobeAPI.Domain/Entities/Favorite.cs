using IDrobeAPI.Domain.Common;
using IDrobeAPI.Domain.Identity;

namespace IDrobeAPI.Domain.Entities
{
    public class Favorite : EntityBase
    {
        public Favorite()
        {
            
        }

        public Favorite(string userId, int productId) : this()
        {
            UserId = userId;
            ProductId = productId;
        }



        // Relation
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }

}
