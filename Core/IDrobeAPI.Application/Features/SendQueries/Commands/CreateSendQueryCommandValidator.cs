//using FluentValidation;
//using IDrobeAPI.Application.Features.SendQueries.Constants;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace IDrobeAPI.Application.Features.SendQueries.Commands;

//public class CreateSendQueryCommandValidator: AbstractValidator<CreateSendQueryCommandRequest>
//{
//    public CreateSendQueryCommandValidator()
//    {
//        RuleFor(x => x.Model.QueryInfo)
//           .NotNull()
//           .WithMessage(SendQueryValidationMessageConstants.modelQueryInfo);

//        RuleFor(x => x.Model.StoreLogos)
//            .NotEmpty().WithMessage(SendQueryValidationMessageConstants.modelStoreLogos)
//            .Must(HaveAtLeastOneLogo).WithMessage(SendQueryValidationMessageConstants.modelStoreLogos)
//            .Must(ContainValidImageFormats).WithMessage(SendQueryValidationMessageConstants.modelStoreLogosFormat); ;

//        RuleFor(x => x.Model.QueryInfo.StoreName)
//            .NotEmpty()
//            .WithMessage(SendQueryValidationMessageConstants.modelQueryInfoStoreNameEmpty).WithName("Store Name");

//        RuleFor(x => x.Model.QueryInfo.PhoneNumber)
//            .NotEmpty().WithMessage(SendQueryValidationMessageConstants.modelQueryInfoPhoneNumberEmpty)
//            .Matches(@"^\+994\s\d{2}\s\d{3}\s\d{4}$")
//            .WithMessage(SendQueryValidationMessageConstants.modelQueryInfoPhoneNumberMatches).WithName("Phone Number");

//        RuleFor(x => x.Model.QueryInfo.Email)
//            .NotEmpty().WithMessage(SendQueryValidationMessageConstants.modelQueryInfoEmailEmpty)
//            .EmailAddress().WithMessage(SendQueryValidationMessageConstants.modelQueryInfoEmailFormat).WithName("Email");

//        RuleFor(x => x.Model.QueryInfo.Addres)
//            .NotEmpty().WithMessage(SendQueryValidationMessageConstants.modelQueryInfoAddresEmpty)
//            .MaximumLength(100).WithMessage(SendQueryValidationMessageConstants.modelQueryInfoAddresLength).WithName("Addres");
//    }

//    private bool HaveAtLeastOneLogo(IFormFileCollection files)
//    {
//        return files != null && files.Any();
//    }

//    private bool ContainValidImageFormats(IFormFileCollection files)
//    {
//        if (files == null || !files.Any())
//            return true;

//        List<string> validExtensions = new List<string> { ".jpg", ".jpeg", ".png" };

//        foreach (var file in files)
//        {
//            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
//            if (!validExtensions.Contains(fileExtension))
//                return false;
//        }

//        return true;
//    }
//}
