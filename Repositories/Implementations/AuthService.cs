using AssetIQ.Models.Domain;
using AssetIQ.Repositories.Interfaces;
using AssetIQ.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace AssetIQ.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(email);

            if (existingUser != null)
            {
                return false;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = passwordHash,
                Role = "User"
            };

            await _userRepository.AddAsync(user);

            return true;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                return null;
            }

            var isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isValid)
            {
                return null;
            }

            return user;
        }

        
    }
}