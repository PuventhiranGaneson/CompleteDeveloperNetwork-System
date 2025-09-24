using System;
using System.Data.Common;
using CompleteDeveloperNetwork_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.Net.Mime.MediaTypeNames;

namespace CompleteDeveloperNetwork_System.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }

        public DbSet<Developers> developers { get; set; }
        public DbSet<Skillsets> Skillsets { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }

        public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
        {
            public DataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

                // fallback connection string for design-time
                optionsBuilder.UseSqlServer(
                    "Data Source = LAPTOP - T22L9867/SQLEXPRESS; Initial Catalog = CDN; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False");

                return new DataContext(optionsBuilder.Options);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //explaining relationship between table 
            modelBuilder.Entity<Skillsets>()
                .HasOne(s => s.developer)
                .WithMany(d => d.skillsets)
                .HasForeignKey(s => s.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hobbies>()
                .HasOne(h => h.developer)
                .WithMany(d => d.hobbies)
                .HasForeignKey(h => h.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);

        
            base.OnModelCreating(modelBuilder);

            // Developers
            modelBuilder.Entity<Developers>().HasData(
                new Developers { Id = 1, Username = "alice_dev", Email = "alice@example.com", PhoneNumber = "0123456789" },
                new Developers { Id = 2, Username = "bob_coder", Email = "bob@example.com", PhoneNumber = "0198765432"},
                new Developers { Id = 3, Username = "charlie_pro", Email = "charlie@example.com", PhoneNumber = "0182222333" }
            );

            // Skillsets
            modelBuilder.Entity<Skillsets>().HasData(
                new Skillsets { Id = 1, Name = "C#", Description = "Backend development", DeveloperId = 1 },
                new Skillsets { Id = 2, Name = "React", Description = "Frontend development", DeveloperId = 1 },
                new Skillsets { Id = 3, Name = "Python", Description = "AI/ML coding", DeveloperId = 2 },
                new Skillsets { Id = 4, Name = "SQL", Description = "Database management", DeveloperId = 2 },
                new Skillsets { Id = 5, Name = "Java", Description = "Enterprise systems", DeveloperId = 3 }
            );

            // Hobbies
            modelBuilder.Entity<Hobbies>().HasData(
                new Hobbies { Id = 1, Name = "Cycling", Description = "Weekend rides", DeveloperId = 1 },
                new Hobbies { Id = 2, Name = "Gaming", Description = "FPS games", DeveloperId = 1 },
                new Hobbies { Id = 3, Name = "Photography", Description = "Landscape photography", DeveloperId = 2 },
                new Hobbies { Id = 4, Name = "Cooking", Description = "Trying new recipes", DeveloperId = 2 },
                new Hobbies { Id = 5, Name = "Traveling", Description = "Exploring new places", DeveloperId = 3 }
            );
 

    }
}
}
