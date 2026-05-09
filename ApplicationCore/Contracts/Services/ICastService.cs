using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastDetailsModel> GetCastDetails(int castId);
    }
}
