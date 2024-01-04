using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
        }                         //base gedib isteltin belke orda nese xususi is gorulub
        public Brand(string name):this()
        {
            Name = name;
        }
        public string Name { get; set; }
    }

}
