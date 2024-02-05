using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Categories.Constants;

public static class CategoryResponseMessageConstants
{
    public const string successfullyCreated = "Category Created Successfully";
    public const string successfullyUpdated = "Category Updated Successfully";
    public const string successfullyDeleted = "Category Deleted Successfully";
    public const string successfullyGetAll = "All Categories Successfuly Returned";
    public const string successfullyGetSingle = "Category Successfuly Returned";
}
