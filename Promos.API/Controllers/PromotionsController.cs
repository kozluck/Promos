using Microsoft.AspNetCore.Mvc;
using Promos.API.Mapping;
using Promos.Application.Services;
using Promos.Contracts.Requests;
using Promos.Contracts.Responses;

namespace Promos.API.Controllers;

[ApiController]
public class PromotionsController : ControllerBase
{
    private readonly IPromotionService _promotionService;

    public PromotionsController(IPromotionService promotionService)
    {
        _promotionService = promotionService;
    }

    [HttpPost(ApiEndpoints.Promotions.Create)]
    [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePromotionRequest request,
        CancellationToken token = default)
    {
        var promotion = request.MapToPromotion();

        await _promotionService.CreateAsync(promotion, token);

        var response = promotion.MapToResponse();

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Promotions.Get)]
    [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken token = default)
    {
        var promotion = await _promotionService.GetByIdAsync(id, token);

        return promotion is null ? NotFound() : Ok(promotion.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Promotions.GetAll)]
    [ProducesResponseType(typeof(PromotionsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken token = default)
    {
        var promotions = await _promotionService.GetAllAsync(token);

        return Ok(promotions.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Promotions.Update)]
    [ProducesResponseType(typeof(PromotionResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdatePromotionRequest request, CancellationToken token = default)
    {
        var updated = await _promotionService.UpdateAsync(request.MapToPromotion(id), token );

        return updated is not null ? Ok(updated.MapToResponse()) : NotFound();
    }

    [HttpDelete(ApiEndpoints.Promotions.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync( Guid id, CancellationToken token = default )
    {
        var deleted = await _promotionService.DeleteByIdAsync(id, token);

        return deleted ? Ok() : NotFound();
    }
}