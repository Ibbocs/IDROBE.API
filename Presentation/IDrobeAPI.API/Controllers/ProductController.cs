using IDrobeAPI.Application.Features.Products.Commands.CreateProduct;
using IDrobeAPI.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDrobeAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()//parametir almadan mediator isletmek
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
