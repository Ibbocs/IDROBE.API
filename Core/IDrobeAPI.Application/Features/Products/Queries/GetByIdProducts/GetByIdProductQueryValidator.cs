using FluentValidation;
using IDrobeAPI.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetByIdProducts;

public class GetByIdProductQueryValidator:AbstractValidator<GetByIdProductQueryRequest>
{
    public GetByIdProductQueryValidator()
    {
        RuleFor(request => request.Id)
            .GreaterThan(0)
            .WithMessage(ProductValidationMessageConstants.categoryId).WithName("Product Id");
    }
}
