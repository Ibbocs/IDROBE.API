using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
        }                         //base gedib isteltin belke orda nese xususi is gorulub
        public Brand(string name, string description, string brandType, string ımagePath) : this()
        {
            BrandName = name;
            Description = description;
            BrandType = brandType;
            ImagePath = ımagePath;
        }
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string BrandType { get; set; }
        public string ImagePath {  get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
