using IDrobeAPI.Application.Features.Products.DTOs;
using IDrobeAPI.Application.Models.PaginationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Model;

public class ProductPaginationListViewModel: BasePageableModel
{
    public IList<ProductGetDTO> Items { get; set; }
}
