using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp_Themed_Events.Models;
// using CSharp_Themed_Events.Services;

namespace CSharp_Themed_Events.Controllers;

public class HomeController : Controller
{
    // private readonly EventService _eventService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        // _eventService = eventService;
    }

    public IActionResult Index()
    {
        // var events = await _eventService.GetEvents();
        // if (events != null) return View(events);
        return View();
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