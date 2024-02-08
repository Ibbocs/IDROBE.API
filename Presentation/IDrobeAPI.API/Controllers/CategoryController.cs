using IDrobeAPI.Application.Features.Categories.Commands.CreateCategories;
using IDrobeAPI.Application.Features.Categories.Commands.DeleteCategories;
using IDrobeAPI.Application.Features.Categories.Commands.UpdateCategories;
using IDrobeAPI.Application.Features.Categories.Queries.GetAllCategories;
using IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryDynamics;
using IDrobeAPI.Application.Features.Categories.Queries.GetAllCategoryPaginations;
using IDrobeAPI.Application.Features.Categories.Queries.GetByIdCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/category/")]
    [ApiController]
    public class CategoryController : BaseController
    {

        [HttpGet("get-all-category")]
        public async Task<IActionResult> GetAllCategory(/*GetAllCategoryQueryRequest request*/)
        {
            var data = await _mediator.Send(new GetAllCategoryQueryRequest());
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-id-category/{Id}")]
        public async Task<IActionResult> GetByIdCategory([FromRoute]GetByIdCategoryQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-pagination-category")]
        public async Task<IActionResult> GetByPaginationCategory([FromQuery] GetByPaginationCategoryQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("get-by-dynamic-category")]
        public async Task<IActionResult> GetByDynamicCategory([FromBody] GetListCategoryByDynamicQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory([FromBody]CreateCategoryCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }


//        {
//  "dynamic": {
//    "sort": [
//      {
//        "field": "Name", //sort eleme istenen field
//        "dir": "asc"
//      }
//    ],
//    "filter": {
//      "field": "Name",
//      "operator": "eq",
//      "value": "Kisi",
//      "logic": "or", //burdan sorasi yazmaya da bilersen, 2ci bir filter elave eleyir bura
//      "filters": [
//        {
//          "field": "Id",
//          "operator": "gte",
//          "value": "8"
//        }
//      ]
//    }
//  },
//  "pageRequest": {
//    "page": 0,
//    "pageSize": 5
//  }
//}
    }
}
