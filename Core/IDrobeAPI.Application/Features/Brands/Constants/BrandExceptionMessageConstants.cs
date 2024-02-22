using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Constants;

public static class BrandExceptionMessageConstants
{
    public const string canNotNull = "Brand can not be empty or null";
    public const string rowAffectProblem = "The request to add or change data failed due to an error. Please check your input and try again.";
    public const string resultProblem = "An error occurred while processing the data. Please check your input and try again.";
    public const string dontFind = "Requested brand does not exist. Please check your input and try again.";
    public const string sameName = "The brand with this name already exists. Please choose a different name.";
}
