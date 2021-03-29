using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Application.Interfaces;

namespace ScoreCombination.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreCombinationController : ControllerBase
    {
        private readonly IApplicationServiceRecord _applicationServiceRecord;

        public ScoreCombinationController(IApplicationServiceRecord applicationServiceRecord)
        {
            _applicationServiceRecord = applicationServiceRecord;
        }

        [HttpPost]
        public ActionResult<ScoreCombinationResultDto> Post([FromBody] ScoreCombinationRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Please add some information to the request.");
            }

            if (request.Sequence == null)
            {
                ModelState.AddModelError(nameof(request.Sequence), "Please add one or more scores to the sequence.");
                return BadRequest(ModelState);
            }

            if (request.Sequence.Any())
            {
                return Ok(_applicationServiceRecord.Post(request));
            }

            return BadRequest(ModelState);
        }

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
