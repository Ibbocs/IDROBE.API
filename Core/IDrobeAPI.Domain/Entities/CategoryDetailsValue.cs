using IDrobeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Domain.Entities
{
    public class CategoryDetailsValue:EntityBase
    {
        public CategoryDetailsValue() { }

        public CategoryDetailsValue(string value, int categoryDetailId, int productId)
        {
            Value = value;
            CategoryDetailId = categoryDetailId;
            ProductId = productId;
        }


        public string Value { get; set; }

        public int CategoryDetailId { get; set; }
        public virtual CategoryDetail CategoryDetail { get; set; }

        public int ProductId { get; set; }//todo lazimmsiz ola biler CategoryDetailValue-ProductId
        public virtual Product Product { get; set; }

    }
}
