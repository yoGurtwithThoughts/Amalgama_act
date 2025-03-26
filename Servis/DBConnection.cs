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
            public DbSet<Users> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=login.db");
            }

            public async Task InitializeDatabaseAsync()
            {
                await Database.EnsureCreatedAsync(); // Создаем базу данных, если она не существует

                // Проверяем, существует ли тестовый пользователь
                if (!await Users.AnyAsync(u => u.Login == "Test"))
                {
                    var defaultUser = new Users
                    {
                        Login = "Test",
                        Password = "Test" // Пароль в открытом виде
                    };

                    Users.Add(defaultUser);
                    await SaveChangesAsync();
                }
            }
        }

        public class Users
        {
            public int Id { get; set; }
            public string Login { get; set; }
            public string Password { get; set; } // Пароль в открытом виде
        }
    }
    }
