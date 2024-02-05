using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Constants;

public static class CategoryValidationMessageConstants
{
    public const string parentId = "ParentId must be greater than or equal to 0";
    public const string name = "Name required and can be up to 100 characters";
    public const string priorty = "Priorty must be greater than 0";
    public const string categoryId = "Category Id required and must be greater than 0";

    public const string page = "Page must be greater than or equal to 0";
    public const string pageSize = "Page Size must be greater than or equal to 0";

    public const string dynamic = "Dynamic json body is required";
}
