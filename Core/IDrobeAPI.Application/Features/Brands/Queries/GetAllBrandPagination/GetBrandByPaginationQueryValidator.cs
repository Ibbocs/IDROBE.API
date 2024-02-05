using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandPagination;

public class GetBrandByPaginationQueryValidator:AbstractValidator<GetBrandByPaginationQueryRequest>
{
    public GetBrandByPaginationQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
            .GreaterThanOrEqualTo(0)
            .WithMessage(BrandValidationMessageConstants.page).WithName("Page");

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(BrandValidationMessageConstants.pageSize).WithName("Page Size");
    }
}
