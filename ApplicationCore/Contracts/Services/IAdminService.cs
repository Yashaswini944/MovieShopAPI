using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<ReportModel>> GetAllReports();
        Task<IEnumerable<UserProfileModel>> GetAllUsers();

        Task<ReportModel> GetReportById(int id);
        Task ResolveReport(int id);
    }
}
