﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<User>()
                    .Property(u => u.IsAdmin)
                    .HasDefaultValue(false); // По умолчанию все пользователи - не админы
            }
            public async Task InitializeDatabaseAsync()
            {
                await Database.EnsureCreatedAsync(); // Создаем базу данных, если она не существует

                // Проверяем, существует ли тестовый пользователь
                if (!await Users.AnyAsync(u => u.Login == "Test"))
                {
                    var defaultUser = new User
                    {
                        Login = "Test",
                        Password = "Test", // Пароль в открытом виде
                        IsAdmin = true
                    };

                    Users.Add(defaultUser);
                    await SaveChangesAsync();
                }
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string Login { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;

            // Новое поле, определяет, является ли пользователь администратором
            public bool IsAdmin { get; set; }
        }
    }
}
