using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoryQueryRequest:IRequest<GenericActionResponse<CategoryListViewModel>>
    {
    }
}
