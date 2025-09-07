using System.Numerics;
using LokusAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LokusAPI.Database
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        #region //User, Customer, Company and Stablishment
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Stablishment> Stablishments { get; set; }
        #endregion

        #region //Images and Gallery
        public DbSet<StablishmentGallery> StablishmentGalleries { get; set; }
        public DbSet<Image> Images { get; set; }
        #endregion

        #region //Company Profile
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        #endregion
        
        #region //Others

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Payment> Payments { get; set; }
        #endregion
    }
}
