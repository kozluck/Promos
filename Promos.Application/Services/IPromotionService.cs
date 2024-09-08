using Promos.Application.Models;

namespace Promos.Application.Services;

public interface IPromotionService
{
    Task<bool> CreateAsync( Promotion promotion, CancellationToken token = default );

    Task<Promotion?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Promotion>> GetAllAsync(CancellationToken token = default);

    Task<Promotion?> UpdateAsync(Promotion promotion, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
}