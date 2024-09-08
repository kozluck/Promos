using Promos.Application.Models;
using Promos.Application.Repositories;

namespace Promos.Application.Services;

public class PromotionService : IPromotionService
{
    private readonly IPromotionRepository _repository;

    public PromotionService(IPromotionRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> CreateAsync(Promotion promotion, CancellationToken token = default)
    {
        return await _repository.CreateAsync(promotion, token);
    }

    public async Task<Promotion?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }

    public async Task<Promotion?> UpdateAsync(Promotion promotion, CancellationToken token = default)
    {
        var exists = await _repository.ExistsByIdAsync(promotion.Id, token);
        
        if ( !exists )
            return null;
        
        return await _repository.UpdateAsync(promotion, token);
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _repository.DeleteByIdAsync(id, token);
    }

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
    {
        return await _repository.ExistsByIdAsync(id, token);
    }
}