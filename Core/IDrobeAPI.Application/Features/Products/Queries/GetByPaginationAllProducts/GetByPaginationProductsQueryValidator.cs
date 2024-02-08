using FluentValidation;
using IDrobeAPI.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByPaginationAllProducts;

public class GetByPaginationProductsQueryValidator:AbstractValidator<GetByPaginationProductsQueryRequest>
{
    public GetByPaginationProductsQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
           .GreaterThanOrEqualTo(0)
           .WithMessage(ProductValidationMessageConstants.page).WithName("Page");

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(ProductValidationMessageConstants.pageSize).WithName("Page Size");
    }
}
