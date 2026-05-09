using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountService
    {
        Task<UserLoginResponseModel> Login(UserLoginRequestModel model);
        Task<UserRegisterResponseModel> Register(UserRegisterRequestModel model);
        Task<bool> EmailExists(string email);
    }
}
