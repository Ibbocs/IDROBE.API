using IDrobeAPI.Application.Features.Brands.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        //bunun adin Brand yazmagimin sebebi mapper basa dusun deyedi, entity icindeki ile eyni olmalidi
        public BrandDTO Brand { get; set; }
    }
}
