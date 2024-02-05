using FluentValidation;
using IDrobeAPI.Application.Features.Categories.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryPaginations;

public class GetByPaginationCategoryQueryValidator:AbstractValidator<GetByPaginationCategoryQueryRequest>
{
    public GetByPaginationCategoryQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage(CategoryValidationMessageConstants.page).WithName("Page");

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(CategoryValidationMessageConstants.pageSize).WithName("Page Size");
    }
}
