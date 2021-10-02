using System;
using Microsoft.EntityFrameworkCore;
using Resources.API.Models;

namespace Resources.API.DataAccess
{
    public class ResourcesDbContext : DbContext
    {
        private readonly string _dbPath;

        public ResourcesDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            _dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}resources.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>().HasData(
               new Booking() { Id = 1, DateFrom = DateTime.Parse("2021-10-02T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-06T00:00:00.000Z"), BookedQuantity = 1, ResourceId = 1 },
               new Booking() { Id = 2, DateFrom = DateTime.Parse("2021-10-03T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-08T00:00:00.000Z"), BookedQuantity = 2, ResourceId = 1 },
               new Booking() { Id = 3, DateFrom = DateTime.Parse("2021-10-04T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-05T00:00:00.000Z"), BookedQuantity = 3, ResourceId = 1 }
            );

            modelBuilder.Entity<Resource>().HasData(
               new Resource() { Id = 1, Name = "Resource 1", Quantity = 10 },
               new Resource() { Id = 2, Name = "Resource 2", Quantity = 5 },
               new Resource() { Id = 3, Name = "Resource 3", Quantity = 10 }
            );
        }

        public DbSet<Resource> ResourcesDbSet { get; set; }
        public DbSet<Booking> BookingDbSet { get; set; }
    }
}
