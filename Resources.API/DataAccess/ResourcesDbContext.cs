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

        public DbSet<Resource> ResourcesDbSet { get; set; }
        public DbSet<Booking> BookingDbSet { get; set; }
    }
}
