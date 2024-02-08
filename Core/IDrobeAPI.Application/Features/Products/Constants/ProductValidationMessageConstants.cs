using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Constants;

public static class ProductValidationMessageConstants
{
    public const string productId = "Product Id must be greater than 0";
    public const string brandId = "Brand Id must be greater than 0";
    public const string title = "Product Title required and can be up to 200 characters";
    public const string description = "Product Description required and can be up to 200 characters";
    public const string price = "Product Price must be greater than 0";
    public const string imagePath = "Product ImagePath must not be empty.";
    public const string color = "Product Color must not be empty and can be up to 100 characters.";
    public const string size = "Product Size must not be empty and can be up to 30 characters.";
    public const string clothesType = "Product Clothes Type must not be empty and can be up to 100 characters.";
    public const string armType = "Product Arm Type must not be empty and can be up to 100 characters.";
    public const string length = "Product Length must be greater than 0.";

    public const string categoryId = "At least one CategoryId must be provided.";
    public const string categoryIdGreater = "Category Id must be greater than 0";

    public const string page = "Page must be greater than or equal to 0";
    public const string pageSize = "Page Size must be greater than or equal to 0";

    public const string dynamic = "Dynamic json body is required";
}
