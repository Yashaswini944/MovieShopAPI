using System;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Helpers
{
    public static class PasswordHasher
    {
        public static string GenerateSalt()
        {
            var randomBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);

            return Convert.ToBase64String(randomBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            var combined = password + salt;
            using var sha256 = SHA256.Create();

            var bytes = Encoding.UTF8.GetBytes(combined);
            var hash = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
