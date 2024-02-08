using IDrobeAPI.Application.Features.Products.Model;
using IDrobeAPI.Application.Models.DynamicQueriesModels;
using IDrobeAPI.Application.Models.PaginationModels;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByDynamicAllProducts;

public class GetByDynamicProductsQueryRequest : 
 IRequest<GenericActionResponse<ProductPaginationListViewModel>>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
    public bool isDeleted { get; set; } = false;
}
