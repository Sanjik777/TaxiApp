using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;

namespace TaxiApp.DataAccess
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Order> Loaction { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    FullName = "Алиса Александровна",               
                    //Comments="Хороший водитель",                    
                },
                new Client
                {
                    FullName = "Иванов Иван",
                    //Comments = "Плохой водитель",
                },
                new Client
                {
                    FullName = "Сергей Шмитд",
                    //Comments = "Плохой водитель",
                });
            modelBuilder.Entity<Driver>().HasData(
               new Driver
               {
                   FullName = "Петрович Петров",
                   Car="Nissan 203"
                
               },
               new Driver
               {
                   FullName = "Алексей Алексеевич",
                   Car = "Lexus 111"
               });
        }
    }
}
