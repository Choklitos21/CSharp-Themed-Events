using Microsoft.EntityFrameworkCore;
using CSharp_Themed_Events.Models;

namespace CSharp_Themed_Events.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
        
    }
    
    public DbSet<Event> Event { get; set; }
}