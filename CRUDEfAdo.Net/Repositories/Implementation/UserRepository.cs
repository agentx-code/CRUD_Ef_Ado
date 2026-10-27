using CRUDEfAdo.Net.Data;
using CRUDEfAdo.Net.Models;
using CRUDEfAdo.Net.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUDEfAdo.Net.Repositories.Ado.Net
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionFactory _connectionFactory;
        private readonly ApplicationDbContext _context;
        public UserRepository(DbConnectionFactory dbConnectionFactory, ApplicationDbContext dbContext)
        {
            _connectionFactory = dbConnectionFactory;
            _context = dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = new List<User>();
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users";
                using (SqlCommand cmd = new SqlCommand(query, conn)) 
                {
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id  = Convert.ToInt32(reader["id"]),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                Address = reader["Address"].ToString(),
                                Images = reader["Images"] == DBNull.Value? null : reader["Images"].ToString()
                            });
                        }
                        return users;
                    }
                }
            }
           
        }

        public async Task<User> CreateAsync(User user)
        {
            using (SqlConnection conn = _connectionFactory.CreateConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, Email,Password, Address,Images ) VALUES( @Name,@Email,@Password,@Address, @Images)";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name" , user.Name);
                    cmd.Parameters.AddWithValue("@Email" , user.Email);
                    cmd.Parameters.AddWithValue("@Password" , user.Password);
                    cmd.Parameters.AddWithValue("@Address", user.Address);
                    cmd.Parameters.AddWithValue("@Images",(object?)user.Images ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
            return user;
        }


        //Entity

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task DeleteAsync(int Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
