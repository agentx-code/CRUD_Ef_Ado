using CRUDEfAdo.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDEfAdo.Net.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
