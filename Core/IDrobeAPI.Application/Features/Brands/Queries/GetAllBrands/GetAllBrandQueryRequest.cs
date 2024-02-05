using IDrobeAPI.Application.Features.Brands.Models;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrands;

public class GetAllBrandQueryRequest:IRequest<GenericActionResponse<BrandListViewModel>>
{
}
