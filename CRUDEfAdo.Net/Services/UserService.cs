using CRUDEfAdo.Net.Models;
using CRUDEfAdo.Net.Repositories.Interface;
using CRUDEfAdo.Net.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CRUDEfAdo.Net.Services
{
    public class UserService : IUserService
    {
      private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
            return user;
        }
        public async Task<User?> GetByIdAsync(int Id)
        {
            return await _userRepository.GetByIdAsync(Id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
            return user;
        }
        public async Task DeleteAsync(int Id)
        {
            var existingUser = await _userRepository.GetByIdAsync( Id);
            if(existingUser == null)
            {
                return;
            }
            await _userRepository.DeleteAsync(Id);
        }
    }
}
