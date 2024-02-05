using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Models.DynamicQueriesModels;
using IDrobeAPI.Application.Models.PaginationModels;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryDynamics;

public class GetListCategoryByDynamicQueryRequest:IRequest<GenericActionResponse<CategoryPaginationListViewModel>>
{
    public Dynamic Dynamic { get; set; }
    public PageRequest PageRequest { get; set; }
}
