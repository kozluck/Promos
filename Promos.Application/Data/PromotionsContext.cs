using Microsoft.EntityFrameworkCore;
using Promos.Application.Models;

namespace Promos.Application.Data;

public class PromotionsContext : DbContext
{
    public DbSet<Promotion> Promotions => Set<Promotion>();
    
    public PromotionsContext( DbContextOptions<PromotionsContext> options ) : base(options) {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql( Environment.GetEnvironmentVariable("ConnectionString") );
        base.OnConfiguring(optionsBuilder);
    }
}