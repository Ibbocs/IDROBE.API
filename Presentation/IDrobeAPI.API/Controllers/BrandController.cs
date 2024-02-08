using IDrobeAPI.Application.Features.Brands.Queries.GetAllBrands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IDrobeAPI.Application.Features.Brands.Commands.DeleteBrands;
using IDrobeAPI.Application.Features.Brands.Commands.UpdateBrands;
using IDrobeAPI.Application.Features.Brands.Commands.CreateBrands;
using IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandDynamic;
using IDrobeAPI.Application.Features.Brands.Queries.GetAllBrandPagination;
using IDrobeAPI.Application.Features.Brands.Queries.GetByIdBrand;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/brand/")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpGet("get-all-brand")]
        public async Task<IActionResult> GetAllBrand()
        {
            var data = await _mediator.Send(new GetAllBrandQueryRequest());
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-id-brand/{Id}")]
        public async Task<IActionResult> GetByIdBrand([FromRoute] GetBrandByIdQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpGet("get-by-pagination-brand")]
        public async Task<IActionResult> GetByPaginationBrand([FromQuery] GetBrandByPaginationQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("get-by-dynamic-brand")]
        public async Task<IActionResult> GetByDynamicBrand([FromBody] GetBrandByDynamicQueryRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPost("create-brand")]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpPut("update-brand")]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }

        [HttpDelete("delete-brand")]
        public async Task<IActionResult> DeleteBrand([FromBody] DeleteBrandCommandRequest request)
        {
            var data = await _mediator.Send(request);
            return StatusCode((int)data.ResponseCode, data);
        }
    }
}
