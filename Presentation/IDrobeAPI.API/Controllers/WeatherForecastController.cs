using Microsoft.AspNetCore.Mvc;
using MediatR;
using IDrobeAPI.Application.Features.Products.Queries.GetAllProducts;
using IDrobeAPI.Application.Interfaces.IAutoMapper;

namespace IDrobeAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        private List<WeatherForecast> _forecasts;
        private ICustomMapper _customMapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator, ICustomMapper customMapper)
        {
            _logger = logger;
            _mediator = mediator;
            _customMapper = customMapper;

            _forecasts = new List<WeatherForecast>();

            for (int i = 0; i < 100; i++)
            {
                _forecasts.Add(new()
                {
                    TemperatureC = i

                });
            }
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()//parametir almadan mediator isletmek
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        //{
        //    await _mediator.Send(request);
        //    return Ok();
        //}

        //[HttpGet("[action]")]
        //public async Task<WeatherListVM> Index([FromQuery] PageRequest request)
        //{
        //    IPaginate<WeatherForecast> paginate = new Paginate<WeatherForecast>(_forecasts, request.Page, request.PageSize,0);

        //    //var brand = _customMapper.Map<List<WeatherForecast>>();

        //    WeatherListVM weatherListVM = _customMapper.Map<WeatherListVM>(paginate);

        //    //IPaginate<Student> brands = await _repo.GetListAsync(index: request.Page, size: request.PageSize);

        //    //StudentListModel mappedBrandListModel = _mapper.Map<StudentListModel>(brands);

        //    return weatherListVM;
        //}

        //public class WeatherListVM:BasePageableModel
        //{
        //    public IList<WeatherForecast>? Items { get; set; }
        //}

        //[HttpPost("[action]")]
        //public async Task<WeatherListVM> IndexByDynamic([FromQuery] PageRequest request, Dynamic dynamic )
        //{
        //    //IPaginate<WeatherForecast> paginate = IPaginate < WeatherForecast > brands = await _repo.GetListByDynamicAsync(dynamic: Dynamic, index: request.Page, size: request.PageSize);

        //    //var brand = _customMapper.Map<List<WeatherForecast>>();

        //    //WeatherListVM weatherListVM = _customMapper.Map<WeatherListVM>(paginate);

        //    //IPaginate<Student> brands = await _repo.GetListAsync(index: request.Page, size: request.PageSize);

        //    //StudentListModel mappedBrandListModel = _mapper.Map<StudentListModel>(brands);

        //    //return weatherListVM;
        //    yield return null; yield return null; yield return null;
        //}
    }
}
