using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Constants;

public static class CategoryExceptionMessageConstants
{
    public const string canNotNull = "Category can not be empty or null";
    public const string rowAffectProblem = "The request to add or change data failed due to an error. Please check your input and try again.";
    public const string resultProblem = "An error occurred while processing the data. Please check your input and try again.";
    public const string dontFindCategory = "Requested category does not exist. Please check your input and try again.";
}
