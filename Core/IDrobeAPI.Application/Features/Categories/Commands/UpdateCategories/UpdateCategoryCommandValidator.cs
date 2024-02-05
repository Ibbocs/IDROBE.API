using FluentValidation;
using IDrobeAPI.Application.Features.Categories.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;

public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommandRequest>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(request => request.ParentId)
            .GreaterThanOrEqualTo(0)
            .WithMessage(CategoryValidationMessageConstants.parentId).WithName("Parent Id");

        RuleFor(request => request.Name)
            .MaximumLength(100)
            .WithMessage(CategoryValidationMessageConstants.name).WithName("Category Name");

        RuleFor(request => request.Priorty)
            .GreaterThan(0)
            .WithMessage(CategoryValidationMessageConstants.priorty).WithName("Priorty");

        RuleFor(request => request.Id)
            .GreaterThan(0)
            .WithMessage(CategoryValidationMessageConstants.categoryId).WithName("Category Id");
    }
}
