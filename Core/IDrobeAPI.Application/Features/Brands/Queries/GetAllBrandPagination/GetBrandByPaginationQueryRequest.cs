using IDrobeAPI.Application.Features.Brands.Models;
using IDrobeAPI.Application.Models.PaginationModels;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandPagination;

public class GetBrandByPaginationQueryRequest:IRequest<GenericActionResponse<BrandPaginationListViewModel>>
{
    public PageRequest PageRequest { get; set; }
}
