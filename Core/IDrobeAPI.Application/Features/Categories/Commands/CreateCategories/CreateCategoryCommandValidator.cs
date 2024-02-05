using FluentValidation;
using IDrobeAPI.Application.Features.Categories.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.CreateCategories;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(request => request.ParentId)
            .GreaterThanOrEqualTo(0)
            .WithMessage(CategoryValidationMessageConstants.parentId).WithName("Parent Id");

        RuleFor(request => request.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(100)
            .WithMessage(CategoryValidationMessageConstants.name).WithName("Category Name");

        RuleFor(request => request.Priorty)
            .GreaterThan(0)
            .WithMessage(CategoryValidationMessageConstants.priorty).WithName("Priorty");

    }
}
