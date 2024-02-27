using FluentValidation;
using IDrobeAPI.Application.Models.SendQueries;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Validations.SendQueriesValidations;

public class SendQueryModelValidator : AbstractValidator<SendQueryModel>
{
    public SendQueryModelValidator()
    {
        RuleFor(x => x.QueryInfo)
           .NotNull()
           .WithMessage(SendQueryModelValidationMessageConstants.Query_Info);

        RuleFor(x => x.StoreLogos)
            .NotEmpty().WithMessage(SendQueryModelValidationMessageConstants.Store_Logos)
            .Must(HaveAtLeastOneLogo).WithMessage(SendQueryModelValidationMessageConstants.Store_Logos)
            .Must(ContainValidImageFormats).WithMessage(SendQueryModelValidationMessageConstants.Store_Logos_Format); ;

        RuleFor(x => x.QueryInfo.StoreName)
            .NotEmpty()
            .WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Store_Name_Empty).WithName("Store Name");

        RuleFor(x => x.QueryInfo.PhoneNumber)
            .NotEmpty().WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Phone_Number_Empty)
            .Matches(@"^\+994\s\d{2}\s\d{3}\s\d{4}$")
            .WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Phone_Number_Matches).WithName("Phone Number");

        RuleFor(x => x.QueryInfo.Email)
            .NotEmpty().WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Email_Empty)
            .EmailAddress().WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Email_Format).WithName("Email");

        RuleFor(x => x.QueryInfo.Addres)
            .NotEmpty().WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Addres_Empty)
            .MaximumLength(100).WithMessage(SendQueryModelValidationMessageConstants.Query_Info_Addres_Length).WithName("Addres");
    }

    private bool HaveAtLeastOneLogo(IFormFileCollection files)
    {
        return files != null && files.Any();
    }

    private bool ContainValidImageFormats(IFormFileCollection files)
    {
        if (files == null || !files.Any())
            return true;

        List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png" };

        foreach (var file in files)
        {
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!validExtensions.Contains(fileExtension))
                return false;
        }

        return true;
    }
}
