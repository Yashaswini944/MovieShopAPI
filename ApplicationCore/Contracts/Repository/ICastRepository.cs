using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepository : IRepository<Cast>
    {
        Task<Cast> GetCastDetails(int castId);
    }
}
