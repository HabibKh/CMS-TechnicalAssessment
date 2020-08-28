using CMS.UsersMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.UsersMicroservice.Data
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) : base(options)
        {
            // Added some test data
            LoadTestData();
        }

        public void LoadTestData()
        {
            var user = new User() { Name = "Tom Hanks" };
            Users.Add(user);
            user = new User() { Name = "Hugh Jackman" };
            Users.Add(user);
            user = new User() { Name = "Christian Bale" };
            Users.Add(user);
            user = new User() { Name = "Al Pacino" };
            Users.Add(user);
            SaveChanges();
        }

        public virtual DbSet<User> Users { get; set; }
    }
}