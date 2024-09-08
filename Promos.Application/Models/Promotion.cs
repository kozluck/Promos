namespace Promos.Application.Models;

public class Promotion
{
    public required Guid Id { get; init; }
    
    public required string Title { get; set; }
    
    public required string Body { get; set; }
    
    public required List<string> Links { get; set; }
    
    public bool Available { get; set; }
    
    public DateTime CreationDate { get; set; }
}