using IDrobeAPI.Application.Features.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Model;

public class ProductListViewModel
{
    public IList<ProductGetDTO> Items { get; set; }
}
