using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Report>> GetReportsByUser(int userId)
        {
            return await _dbContext.Reports
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}
