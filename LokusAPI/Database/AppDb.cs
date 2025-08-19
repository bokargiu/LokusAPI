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
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categoryes { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ScoreForStablishment> ScoresOfStablishment { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Stablishment> Stablishments { get; set; }
    }
}
