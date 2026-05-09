using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Cast> GetCastDetails(int castId)
        {
            return await _dbContext.Casts
                .Include(c => c.Movies).ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(c => c.Id == castId);
        }
    }
}
