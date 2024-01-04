using IDrobeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Domain.Entities
{
    public class Category:EntityBase
    {
        public Category()
        {

        }
        public Category(int parentId, string name, int priorty) : this()
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }
        public int ParentId { get; set; }//Electronic en boyuk categorydi 0 olur bu id, amma kompda ve printerde bu Electronic idsi olur. Sub category idare elemek olur bu sayede
        public string Name { get; set; }
        public int Priorty { get; set; }//Electronic cat. olan kompun priorty 1 olur, amma printerin 2 meselen
        public ICollection<CategoryDetail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

