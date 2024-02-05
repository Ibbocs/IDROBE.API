using IDrobeAPI.Application.Features.Categories.Models;
using IDrobeAPI.Application.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetByIdCategories;

public class GetByIdCategoryQueryRequest:IRequest<GenericActionResponse<CategorySingleViewModel>>
{
    public int Id { get; set; }
}
