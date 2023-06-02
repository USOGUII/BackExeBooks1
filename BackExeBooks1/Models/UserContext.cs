using BackExeBooks1.Models;
using Microsoft.EntityFrameworkCore;

namespace BackExeBooks1.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
