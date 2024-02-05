using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Brands.Constants
{
    public static class BrandValidationMessageConstants
    {
        public const string name = "Name required and can be up to 256 characters";
        public const string brandType = "Brand Type required and must be either 'Stores' or 'Brands'";
        public const string description = "Description can be up to 256 characters";
        public const string brandId = "Brand Id required and must be greater than 0";


        public const string page = "Page must be greater than or equal to 0";
        public const string pageSize = "Page Size must be greater than or equal to 0";
        public const string dynamic = "Dynamic json body is required";
    }
}
