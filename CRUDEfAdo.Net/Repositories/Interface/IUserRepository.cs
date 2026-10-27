using CRUDEfAdo.Net.Models;

namespace CRUDEfAdo.Net.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int Id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(int Id);
    }
}
