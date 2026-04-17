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
}