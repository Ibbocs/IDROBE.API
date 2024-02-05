using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandDynamic;

public class GetBrandByDynamicQueryValidator:AbstractValidator<GetBrandByDynamicQueryRequest>
{
    public GetBrandByDynamicQueryValidator()
    {
        RuleFor(request => request.PageRequest.Page)
           .GreaterThanOrEqualTo(0)
           .WithMessage(BrandValidationMessageConstants.page).WithName("Page"); //todo bulari bir base hala cixard - Validator message Constants

        RuleFor(request => request.PageRequest.PageSize)
           .GreaterThanOrEqualTo(0)
           .WithMessage(BrandValidationMessageConstants.pageSize).WithName("Page Size");

        RuleFor(request => request.Dynamic)
            .NotNull()
            .WithMessage(BrandValidationMessageConstants.dynamic).WithName("Dynamic Object");
    }
}
