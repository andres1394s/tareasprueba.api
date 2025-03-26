using Microsoft.AspNetCore.Mvc;
using tareasprueba.api.Interfaces;
using tareasprueba.api.Models;

namespace tareasprueba.api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ITareasRepositories _tareasRepositories;
    public WeatherForecastController(ITareasRepositories tareasRepositories)
    {
        _tareasRepositories = tareasRepositories;
    }

    
}

