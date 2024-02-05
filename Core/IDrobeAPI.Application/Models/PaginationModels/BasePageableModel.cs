using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Models.PaginationModels
{
    public class BasePageableModel
    {
        public int Index { get; set; }//hansi page
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }//nece page var
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
