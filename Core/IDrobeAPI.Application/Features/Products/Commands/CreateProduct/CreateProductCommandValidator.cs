using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Product Title");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Product Description");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Product Brand")
                .WithMessage("Id can greater than 0");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Product Price");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("Product Discount");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Product Categories");

        }
    }
}
