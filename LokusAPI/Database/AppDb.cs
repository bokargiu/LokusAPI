using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Database
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companys { get; set; }
    }
}
