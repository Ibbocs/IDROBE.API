using FluentValidation;
using IDrobeAPI.Application.Features.Brands.Constants;
using IDrobeAPI.Application.Features.Categories.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Commands.CreateBrands;

public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommandRequest>
{
    public CreateBrandCommandValidator()
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
    }
}
