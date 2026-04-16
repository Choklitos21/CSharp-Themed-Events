using Microsoft.AspNetCore.Mvc;
using CSharp_Themed_Events.Models;
using CSharp_Themed_Events.Services;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Themed_Events.Controllers;

public class EventController : Controller
{

    private readonly EventService _eventService;

    // .NET inyectará el servicio automáticamente aquí
    public EventController(EventService eventService)
    {
        _eventService = eventService;
    }
    
    // [HttpPost]
    // public async Task<IActionResult> CreateEvent(Event newEvent)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Users.Add(newUser);
    //         await _context.SaveChangesAsync();
    //         return RedirectToAction();
    //     }
    //
    //     return View(newUser);
    // }
    
    // public async Task<IActionResult> Index()
    // {
    //     var events = _eventService.GetEvents();
    //     if (events != null) return View(events);
    //     return View();
    // }

}