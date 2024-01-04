using IDrobeAPI.Domain.Common;

namespace IDrobeAPI.Domain.Entities
{
    public class CategoryDetail : EntityBase
    {
        //her category'de ferli xusiyyetler ola biler: Kompda ram - yaddas olanda, geyimde reng-beden ola biler meselen
        public CategoryDetail()
        {

        }
        public CategoryDetail(string title, string description, int categoryId) : this()
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

}
