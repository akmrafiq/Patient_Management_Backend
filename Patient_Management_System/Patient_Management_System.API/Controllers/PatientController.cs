using Microsoft.AspNetCore.Mvc;
using Patient_Management_System.Core.Entities;
using Patient_Management_System.Core.Services;

namespace Patient_Management_System.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IPatientService _petService;

    public PatientController(ILogger<WeatherForecastController> logger, IPatientService petService)
    {
        _logger = logger;
        _petService = petService;
    }

    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create(Patient patient)
    {
        return Ok(await _petService.Create(patient));
    }

    [HttpGet(Name = "Get")]
    public async Task<IActionResult> Get()
    {
        return Ok(await _petService.Get());
    }
}