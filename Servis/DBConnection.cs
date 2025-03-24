using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amalgama.Servis
{
    public class DBConnection
    {
        public class ApplicationDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=login.db");
            }

            public async Task InitializeDatabaseAsync()
            {
                await Database.EnsureCreatedAsync(); // Create database if it doesn't exist

                // Check if the default user already exists
                if (!await Users.AnyAsync(u => u.Login == "Test"))
                {
                    // Create a new user with the predefined credentials
                    var defaultUser = new User
                    {
                        Login = "Test",
                        Password = "Test" // Make sure to hash the password for security in a real app
                    };

                    Users.Add(defaultUser);
                    await SaveChangesAsync();
                }
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; } // Store hashed passwords for security
        }
    }
}
