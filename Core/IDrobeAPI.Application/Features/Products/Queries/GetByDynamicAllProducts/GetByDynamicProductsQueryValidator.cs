using FluentValidation;
using IDrobeAPI.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByDynamicAllProducts;

public class GetByDynamicProductsQueryValidator:AbstractValidator<GetByDynamicProductsQueryRequest>
{
    public GetByDynamicProductsQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
           .GreaterThanOrEqualTo(0)
           .WithMessage(ProductValidationMessageConstants.page).WithName("Page");

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(ProductValidationMessageConstants.pageSize).WithName("Page Size");

        RuleFor(request => request.Dynamic)
            .NotNull()
            .WithMessage(ProductValidationMessageConstants.dynamic).WithName("Dynamic Object");
    }
}
