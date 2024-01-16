using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Models.PaginationModels
{
    public class PageRequest
    {
        [DefaultValue(0)]
        public int Page { get; set; }
        [DefaultValue(5)]
        public int PageSize { get; set; }
    }
}
