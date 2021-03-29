using Microsoft.AspNetCore.Mvc;
using ScoreCombination.Domain.Entities;
using ScoreCombination.Infrastructure.Data.Database;

namespace ScoreCombination.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreCombinationController : ControllerBase
    {
        private readonly ScoreCombinationDbContext _context;

        public ScoreCombinationController(ScoreCombinationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(ScoreCombinationRequest request)
        {
            //if (!ModelState.IsValid) return BadRequest();

            //try
            //{
            //    return 
            //}
            //var newId = _context.Record.Select(x => x.Id).Max() + 1;

            return Ok();
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
