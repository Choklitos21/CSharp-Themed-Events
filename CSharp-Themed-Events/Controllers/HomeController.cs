using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp_Themed_Events.Models;
using CSharp_Themed_Events.Services;

namespace CSharp_Themed_Events.Controllers;

public class HomeController : Controller
{
    private readonly EventService _eventService;
    private readonly ILogger<HomeController> _logger;

    public HomeController(EventService eventService, ILogger<HomeController> logger)
    {
        _eventService = eventService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var events = await _eventService.GetEvents();
        var viewModel = new EventViewModel
        {
            EventList = events,
            NewEvent = new Event()
        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(Event newEvent)
    {
        if (ModelState.IsValid)
        {
            await _eventService.AddEvent(newEvent);
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}