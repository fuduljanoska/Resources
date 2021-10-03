using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.API.DataAccess
{
    public static class DbInitializer
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder applicationBuilder)
        {
            var serviceProvider = applicationBuilder.ApplicationServices;
            var dbContext = (ResourcesDbContext)serviceProvider.GetService(typeof(ResourcesDbContext));
            dbContext.Database.EnsureCreated();
            int resourcesEntriesCount = dbContext.ResourcesDbSet.Count();
            if(resourcesEntriesCount == 0)
            {
                dbContext.ResourcesDbSet.AddRange(
                   new Resource() { Id = 1, Name = "Resource 1", Quantity = 10 },
                   new Resource() { Id = 2, Name = "Resource 2", Quantity = 5 },
                   new Resource() { Id = 3, Name = "Resource 3", Quantity = 10 }
                );
            }

            int bookingEntriesCount = dbContext.BookingDbSet.Count();
            if(bookingEntriesCount == 0)
            {
                dbContext.BookingDbSet.AddRange(
                   new Booking() { Id = 1, DateFrom = DateTime.Parse("2021-10-02T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-06T00:00:00.000Z"), BookedQuantity = 1, ResourceId = 1 },
                   new Booking() { Id = 2, DateFrom = DateTime.Parse("2021-10-03T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-08T00:00:00.000Z"), BookedQuantity = 2, ResourceId = 1 },
                   new Booking() { Id = 3, DateFrom = DateTime.Parse("2021-10-04T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-05T00:00:00.000Z"), BookedQuantity = 3, ResourceId = 1 }
                );
            }

            dbContext.SaveChanges();

            return applicationBuilder;
        }
    }
}
