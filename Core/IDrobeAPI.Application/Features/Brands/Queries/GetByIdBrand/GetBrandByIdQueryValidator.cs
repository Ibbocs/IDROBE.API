using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Queries.GetByIdBrand;

public class GetBrandByIdQueryValidator:AbstractValidator<GetBrandByIdQueryRequest>
{
    public GetBrandByIdQueryValidator()
    {
        RuleFor(request => request.Id)
       .GreaterThan(0)
       .WithMessage(BrandValidationMessageConstants.brandId).WithName("Brand Id");
    }
}
