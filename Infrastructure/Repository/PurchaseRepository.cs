using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUser(int userId)
        {
            return await _dbContext.Purchases
                .Where(p => p.UserId == userId)
                .Include(p => p.Movie)
                .ToListAsync();
        }

        public async Task<bool> IsMoviePurchased(int userId, int movieId)
        {
            return await _dbContext.Purchases
                .AnyAsync(p => p.UserId == userId && p.MovieId == movieId);
        }
    }
}
