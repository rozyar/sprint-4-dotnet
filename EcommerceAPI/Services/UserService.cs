using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using System.Collections.Generic; // Adicione este using
using System.Threading.Tasks;

namespace EcommerceAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Aplicação do Dependency Injection (DIP)
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        // Implementação dos métodos do serviço
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}