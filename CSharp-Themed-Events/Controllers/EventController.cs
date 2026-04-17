using System.Text.Json;
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

    public async Task<IActionResult> EditEvent(Event newEvent)
    {
        
        if (ModelState.IsValid)
        {
            await _eventService.UpdateEvent(newEvent);
        }

        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        await _eventService.DeleteEvent(id);

        return RedirectToAction("Index", "Home");
    }
}