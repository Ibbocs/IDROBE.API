﻿using IDrobeAPI.Application.Features.Products.Commands.DeleteProducts;
using IDrobeAPI.Application.Features.Products.Commands.ProductCreatings;
using IDrobeAPI.Application.Features.Products.Commands.UpdateProducts;
using IDrobeAPI.Application.Features.Products.Queries.GetAllProducts;
using IDrobeAPI.Application.Features.Products.Queries.GetByDynamicAllProducts;
using IDrobeAPI.Application.Features.Products.Queries.GetByIdProducts;
using IDrobeAPI.Application.Features.Products.Queries.GetByPaginationAllProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/product/")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-id-product")]
        public async Task<IActionResult> GetByIdProduct([FromQuery] GetByIdProductQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-pagination-product")]
        public async Task<IActionResult> GetByPaginationProduct([FromQuery]GetByPaginationProductsQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("get-by-dynamic-product")]
        public async Task<IActionResult> GetByDynamicProduct([FromBody] GetByDynamicProductsQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }


        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }
    }

}
//{
//  "brandId": 2,
//  "title": "Ürün Başlığı",
//  "description": "Ürün Açıklaması",
//  "price": 100,
//  "imagePath": "resimler/urun.jpg",
//  "isNew": true,
//  "size": "XL",
//  "color": "Siyah",
//  "length": 50,
//  "clothesType": "Gömlek",
//  "armType": "Kısa Kollu",
//  "categoryIds": [22, 23, 24]
//}

//{
//    "dynamic": {
//        "sort": [
//          {
//            "field": "Title",
//        "dir": "asc"
//          }
//    ],
//    "filter": {
//            "logic": "or",
//      "field": "Size",
//      "operator": "eq",
//      "value": "M",
//      "filters": [
//        {
//                "field": "brand.Id", //barand id gore filtireledi
//          "operator": "gte",
//          "value": "2"
//        }
//      ]
//    }
//    },
//  "pageRequest": {
//        "page": 0,
//    "pageSize": 10
//  },
//  "isDeleted": false
//}