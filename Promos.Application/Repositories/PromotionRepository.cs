using Microsoft.EntityFrameworkCore;
using Promos.Application.Data;
using Promos.Application.Models;

namespace Promos.Application.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly PromotionsContext _context;

    public PromotionRepository(PromotionsContext context)
    {
        _context = context;
    }


    public async Task<bool> CreateAsync(Promotion promotion, CancellationToken token = default)
    {
        await _context.Promotions.AddAsync(promotion, token);

        var result = await _context.SaveChangesAsync( token );

        return result > 0;
    }

    public async Task<Promotion?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var result = await _context.Promotions.SingleOrDefaultAsync( promotion => promotion.Id == id, token );

        return result;
    }

    public async Task<IEnumerable<Promotion>> GetAllAsync(CancellationToken token = default)
    {
        var result = await _context.Promotions.ToListAsync(token);

        return result;
    }

    public async Task<Promotion?> UpdateAsync(Promotion promotion, CancellationToken token = default)
    {
        var existing = await _context.Promotions.FindAsync(promotion, token);

        if (existing is null)
            return null;
            
        existing.Title = promotion.Title;
        existing.Body = promotion.Body;
        existing.Links = promotion.Links;
        existing.Available = promotion.Available;

        await _context.SaveChangesAsync(token);

        return existing;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var existing = await _context.Promotions.FindAsync(id, token);

        if (existing is null)
            return false;

        _context.Promotions.Remove(existing);

        await _context.SaveChangesAsync(token);

        return true;
    }

    public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default)
    {
        var existing = await _context.Promotions.FindAsync(id, token);

        return existing is not null;
    }
}