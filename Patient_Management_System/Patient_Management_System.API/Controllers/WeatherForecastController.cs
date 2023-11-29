using Microsoft.AspNetCore.Mvc;
using Patient_Management_System.Core.Services;

namespace Patient_Management_System.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPatientService _petService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IPatientService petService)
    {
        _logger = logger;
        _petService = petService;
    }
}