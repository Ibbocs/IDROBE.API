using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Commands.UpdateBrands;

public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommandRequest>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(request => request.BrandName)
        .NotEmpty()
        .NotNull()
        .MaximumLength(256)
        .WithMessage(BrandValidationMessageConstants.name).WithName("Brand Name");

        RuleFor(request => request.BrandType)
           .NotEmpty()
           .NotNull()
           .MaximumLength(30)
           .Must(type => type == "Stores" || type == "Brands")
           .WithMessage(BrandValidationMessageConstants.brandType).WithName("Brand Type");

        RuleFor(request => request.Description)
           .MaximumLength(256)
           .WithMessage(BrandValidationMessageConstants.description).WithName("Brand Description");

        RuleFor(request => request.Id)
            .GreaterThan(0)
            .WithMessage(BrandValidationMessageConstants.brandId).WithName("Brand Id");
    }
}
