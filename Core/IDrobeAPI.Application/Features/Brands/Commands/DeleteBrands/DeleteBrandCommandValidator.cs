using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Commands.DeleteBrands;

public class DeleteBrandCommandValidator:AbstractValidator<DeleteBrandCommandRequest>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(request => request.Id)
            .GreaterThan(0)
            .WithMessage(BrandValidationMessageConstants.brandId).WithName("Brand Id");
    }
}
