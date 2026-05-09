using System.Threading.Tasks;
using Infrastructure.Helpers;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginResponseModel> Login(UserLoginRequestModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null) return null;

            var hashed = PasswordHasher.HashPassword(model.Password, user.Salt);

            if (hashed != user.HashedPassword)
                return null;

            return new UserLoginResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<UserRegisterResponseModel> Register(UserRegisterRequestModel model)
        {
            if (await _userRepository.EmailExists(model.Email))
                return null;

            var salt = PasswordHasher.GenerateSalt();
            var hashed = PasswordHasher.HashPassword(model.Password, salt);

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Salt = salt,
                HashedPassword = hashed
            };

            await _userRepository.Add(user);

            return new UserRegisterResponseModel
            {
                Id = user.Id,
                Email = user.Email
            };
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _userRepository.EmailExists(email);
        }
    }
}
