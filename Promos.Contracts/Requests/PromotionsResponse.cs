using Promos.Contracts.Responses;

namespace Promos.Contracts.Requests;

public class PromotionsResponse
{
    public required IEnumerable<PromotionResponse> Items { get; init; } = Enumerable.Empty<PromotionResponse>();
}