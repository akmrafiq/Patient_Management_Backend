using Microsoft.AspNetCore.Mvc;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Core.Services;

namespace Patient_Management_System.API.Controllers
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
        private readonly IPatientService _petService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPatientService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetPatient")]
        public async Task<IActionResult> GetPatient()
        {
            return Ok(await _petService.Get());
        }
    }

}