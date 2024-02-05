using FluentValidation;
using IDrobeAPI.Application.Features.Categories.Constants;
using IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryPaginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryDynamics;

public class GetListCategoryByDynamicQueryValidator: AbstractValidator<GetListCategoryByDynamicQueryRequest>
{
    public GetListCategoryByDynamicQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
           .GreaterThanOrEqualTo(0)
           .WithMessage(CategoryValidationMessageConstants.page).WithName("Page");

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(CategoryValidationMessageConstants.pageSize).WithName("Page Size");

        RuleFor(request=> request.Dynamic)
            .NotNull()
            .WithMessage(CategoryValidationMessageConstants.dynamic).WithName("Dynamic Object");
    }
}
