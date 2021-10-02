using Resources.API.DataAccess;
using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        private ResourcesDbContext _resoucesDbContext;

        public BookingsRepository(ResourcesDbContext resourcesDbContext)
        {
            _resoucesDbContext = resourcesDbContext;
        }

        public IEnumerable<Booking> GetBookingsByResourceAndDates(DateTime dateFrom, DateTime dateTo, int resourceId)
        {
            return _resoucesDbContext.BookingDbSet
                    .Where(x => x.ResourceId == resourceId && dateFrom <= x.DateTo && dateTo >= x.DateFrom);
        }

        public async Task<Booking> InsertBookingAsync(Booking booking)
        {
            var entityEntry = await _resoucesDbContext.BookingDbSet.AddAsync(booking);
            int numWrittenEntries = await _resoucesDbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
