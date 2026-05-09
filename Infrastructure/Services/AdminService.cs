using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(IReportRepository reportRepository, IUserRepository userRepository)
        {
            _reportRepository = reportRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<ReportModel>> GetAllReports()
        {
            var reports = await _reportRepository.GetAll();

            return reports.Select(r => new ReportModel
            {
                Id = r.Id,
                UserId = r.UserId,
                Issue = r.Issue,
                CreatedDate = r.CreatedDate
            });
        }

        public async Task<ReportModel> GetReportById(int id)
        {
            var report = await _reportRepository.GetById(id);
            if (report == null) return null;

            return new ReportModel
            {
                Id = report.Id,
                UserId = report.UserId,
                Issue = report.Issue,
                CreatedDate = report.CreatedDate
            };
        }

        public async Task<IEnumerable<UserProfileModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return users.Select(u => new UserProfileModel
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName
            });
        }

        public async Task ResolveReport(int id)
        {
            await _reportRepository.Delete(id);
        }
    }
}
