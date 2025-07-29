using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Database
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Clients { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
