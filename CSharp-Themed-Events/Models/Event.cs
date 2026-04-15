using CSharp_Themed_Events.Enums;

namespace CSharp_Themed_Events.Models;

public class Event
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? ImgURL { get; set; }
    public EventStatus Status { get; set; }
}