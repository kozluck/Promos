using Promos.Application.Models;
using Promos.Contracts.Requests;
using Promos.Contracts.Responses;

namespace Promos.API.Mapping;

public static class PromotionMapping
{
    public static Promotion MapToPromotion(this CreatePromotionRequest request)
    {
        return new Promotion
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Body = request.Body,
            Links = request.Links,
            CreationDate = DateTime.UtcNow,
            Available = true
        };
    }

    public static PromotionResponse MapToResponse(this Promotion promotion)
    {
        return new PromotionResponse
        {
            Id = promotion.Id,
            Title = promotion.Title,
            Body = promotion.Body,
            Links = promotion.Links,
            CreationDate = promotion.CreationDate,
            Available = promotion.Available
        };
    }

    public static PromotionsResponse MapToResponse(this IEnumerable<Promotion> promotions)
    {
        return new PromotionsResponse
        {
            Items = promotions.Select(promotion => new PromotionResponse
            {
                Id = promotion.Id,
                Title = promotion.Title,
                Body = promotion.Body,
                Links = promotion.Links,
                CreationDate = promotion.CreationDate,
                Available = promotion.Available
            })
        };
    }

    public static Promotion MapToPromotion(this UpdatePromotionRequest request, Guid id)
    {
        return new Promotion
        {
            Id = id,
            Available = request.Available,
            Body = request.Body,
            Links = request.Links,
            Title = request.Title
        };
    }
}