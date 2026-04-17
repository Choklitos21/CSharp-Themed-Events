using System.Text.Json;
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
    
    public async Task<List<Event>> GetEvents()
    {
        return await _context.Event.ToListAsync();
    }

    public async Task AddEvent(Event newEvent)
    {
        await _context.AddAsync(newEvent);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEvent(Event newEvent)
    {
        var oldEvent = await _context.Event.FirstOrDefaultAsync(x => x.Id == newEvent.Id);
        
        if (oldEvent != null)
        {
            _context.Entry(oldEvent).CurrentValues.SetValues(newEvent);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task DeleteEvent(int id)
    {
        var oldEvent = await _context.Event.FirstOrDefaultAsync(x => x.Id == id);
        Console.WriteLine();
        if (oldEvent != null)
        {
            _context.Remove(oldEvent);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Event>> FilterEvents(DateTime? startDate, DateTime? endDate, int? status)
    {
        IQueryable<Event> query = _context.Event;

        if (startDate.HasValue)
        {
            query = query.Where(e => e.Date >= startDate.Value);
        }
        
        if (endDate.HasValue)
        {
            query = query.Where(e => e.Date <= endDate.Value);
        }

        if (status.HasValue && status.Value > 0)
        {
            query = query.Where(e => (int)e.Status == status.Value);
        }

        return await query.ToListAsync();
    }
}