using CSharp_Themed_Events.Models;
using CSharp_Themed_Events.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Themed_Events.Controllers;

public class GalleryController: Controller
{
    private readonly EventService _eventService;
    
    public GalleryController(EventService eventService)
    {
        _eventService = eventService;
    }
    
    public async Task<IActionResult> Gallery(DateTime? startDate, DateTime? endDate, int? status)
    {
        List<Event> events;
        
        if (startDate.HasValue || endDate.HasValue || status.HasValue)
        {
            events = await _eventService.FilterEvents(startDate, endDate, status);
            
            ViewData["StartDate"] = startDate?.ToString("yyyy-MM-dd");
            ViewData["EndDate"] = endDate?.ToString("yyyy-MM-dd");
            ViewData["CurrentStatus"] = status;
            return View(events);
        }

        events = await _eventService.GetEvents();
        
        return View(events);
    }
}