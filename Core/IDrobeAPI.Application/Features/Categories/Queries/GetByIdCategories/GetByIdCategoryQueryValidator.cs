using FluentValidation;
using IDrobeAPI.Application.Features.Categories.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetByIdCategories;

public class GetByIdCategoryQueryValidator:AbstractValidator<GetByIdCategoryQueryRequest>
{
    public GetByIdCategoryQueryValidator()
    {
        RuleFor(request => request.Id)
       .GreaterThan(0)
       .WithMessage(CategoryValidationMessageConstants.categoryId).WithName("Category Id");
    }
}
