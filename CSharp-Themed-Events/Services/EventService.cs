using CSharp_Themed_Events.Data;
using CSharp_Themed_Events.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharp_Themed_Events.Services;

public class EventService
{
    private readonly AppDbContext _context;

    public EventService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    
    public async Task<List<Event>>? GetEvents()
    {
        return await _context.Event.ToListAsync();
    }
}