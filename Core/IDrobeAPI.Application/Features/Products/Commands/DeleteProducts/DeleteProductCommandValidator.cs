using FluentValidation;
using IDrobeAPI.Application.Features.Products.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Commands.DeleteProducts;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(request => request.Id)
           .GreaterThan(0)
           .WithMessage(ProductValidationMessageConstants.categoryId).WithName("Product Id");
    }
}
