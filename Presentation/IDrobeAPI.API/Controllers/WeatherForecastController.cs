using Microsoft.AspNetCore.Mvc;
using MediatR;
using IDrobeAPI.Application.Features.Products.Queries.GetAllProducts;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using IDrobeAPI.Application.Interfaces.IMails;
using IDrobeAPI.Application.Models.Mails;
using IDrobeAPI.Application.Interfaces.IServices.SendQueryServices;
using IDrobeAPI.Application.Models.SendQueries;

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
        private readonly ISendQueryService _queryService;
        private List<WeatherForecast> _forecasts;
        private ICustomMapper _customMapper;
        private IMailService _mailService;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator, ICustomMapper customMapper, IMailService mailService, ISendQueryService queryService)
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
            _mailService = mailService;
            _queryService = queryService;
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

        [HttpGet("g1")]
        public async Task<IActionResult> GetAllProducts()//parametir almadan mediator isletmek
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }

        [HttpPost("po1")]
        public void SendMail([FromBody]Mail model)
        {
            _mailService.SendMail(model);
        }

        [HttpPost("po2")]
        public void SendQuery([FromQuery] SendQueryModel model)//FromForm
        {
            //SendQueryModel sendQueryModel = new SendQueryModel();
            //sendQueryModel.QueryInfo = model;
            //sendQueryModel.StoreLogo.Add(file);

            var data = _queryService.SendQuery(model);
        }

        //[HttpPost("po3")]
        //public void SendQueryMedi([FromForm] CreateSendQueryCommandRequest request)//FromForm
        //{
        //    var data = _mediator.Send(request);
        //}


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
