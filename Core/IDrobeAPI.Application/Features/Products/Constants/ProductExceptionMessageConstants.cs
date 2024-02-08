using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Constants;

public static class ProductExceptionMessageConstants
{
    public const string canNotNull = "Product can not be empty or null";
    public const string rowAffectProblemProduct = "The request to add or change Product failed due to an error. Please check your input and try again.";
    public const string rowAffectProblemProductCategory = "The request to add or change Product Categories failed due to an error, but Product successful added. Please check your input and try again.";
    public const string resultProblemProduct = "An error occurred while processing the Praduct. Please check your input and try again.";
    public const string resultProblemProductCategory = "An error occurred while processing the Product Category. Please check your input and try again.";

    public const string dontFindProduct = "Requested product does not exist. Please check your input and try again.";
    public const string dontFindCategory = "Categories with the following IDs do not exist:";
    public const string dontFindBrand = "Brand with the following IDs do not exist:";
    public const string duplicateCategoryId = "Duplicate category IDs found:";
}
