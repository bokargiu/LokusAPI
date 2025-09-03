using System.Numerics;
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
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

    }
}
