using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Models.PaginationModels;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryPaginations;

public class GetByPaginationCategoryQueryRequest:IRequest<GenericActionResponse<CategoryPaginationListViewModel>>
{
    public PageRequest PageRequest { get; set; }
}
