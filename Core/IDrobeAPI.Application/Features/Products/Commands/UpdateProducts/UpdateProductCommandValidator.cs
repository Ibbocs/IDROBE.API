using FluentValidation;
using IDrobeAPI.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.UpdateProducts;

public class UpdateProductCommandValidator: AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(request => request.Id)
            .GreaterThan(0)
            .WithMessage(ProductValidationMessageConstants.categoryId).WithName("Product Id");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .WithMessage(ProductValidationMessageConstants.brandId).WithName("Product Brand Id");

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage(ProductValidationMessageConstants.title).WithName("Product Title");

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage(ProductValidationMessageConstants.description).WithName("Product Description");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage(ProductValidationMessageConstants.price).WithName("Product Price");

        RuleFor(x => x.ImagePath)
            .NotEmpty()
            .WithMessage(ProductValidationMessageConstants.imagePath).WithName("Product Image Path");

        RuleFor(x => x.Size)
            .NotEmpty()
            .MaximumLength(30)
            .WithMessage(ProductValidationMessageConstants.size).WithName("Product Size");

        RuleFor(x => x.Color)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage(ProductValidationMessageConstants.color).WithName("Product Color");

        RuleFor(x => x.Length)
            .GreaterThan(0)
            .WithMessage(ProductValidationMessageConstants.length).WithName("Product Length");

        RuleFor(x => x.ClothesType)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage(ProductValidationMessageConstants.clothesType).WithName("Product Clothes Type");

        RuleFor(x => x.ArmType)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage(ProductValidationMessageConstants.armType).WithName("Product Arm Type");

        RuleFor(x => x.CategoryIds)
            .NotEmpty().WithMessage(ProductValidationMessageConstants.categoryId)
            .Must(ids => ids != null && ids.Any()).WithMessage(ProductValidationMessageConstants.categoryId)
            .ForEach(categoryId =>
            {
                categoryId.GreaterThan(0).WithMessage(ProductValidationMessageConstants.categoryIdGreater);
            });
    }
}
