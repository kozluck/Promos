namespace Promos.Contracts.Requests;

public class UpdatePromotionRequest
{
    public required string Title { get; init; }
    
    public required string Body { get; init; }
    
    public required List<string> Links { get; init; }
    
    public required bool Available { get; init; }
}