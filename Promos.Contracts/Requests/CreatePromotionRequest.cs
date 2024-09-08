namespace Promos.Contracts.Requests;

public class CreatePromotionRequest
{
    public required string Title { get; init; }
    
    public required string Body { get; init; }
    
    public required List<string> Links { get; init; }
}