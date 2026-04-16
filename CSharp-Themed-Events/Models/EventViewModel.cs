namespace CSharp_Themed_Events.Models;

public class EventViewModel
{
    // Para la tabla (Lista)
    public IEnumerable<Event> EventList { get; set; } = new List<Event>();

    // Para el formulario (Creación)
    public Event NewEvent { get; set; } = new Event();
}