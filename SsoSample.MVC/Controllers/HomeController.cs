using Newtonsoft.Json;
using System.Diagnostics;
using SsoSample.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace SsoSample.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _client;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory factory)
    {
        _client = factory.CreateClient("w");
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var resultString = await _client.GetStringAsync("/WeatherForecast");
        var result = JsonConvert.DeserializeObject<List<WeatherForecast>>(resultString);
        return View(result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
