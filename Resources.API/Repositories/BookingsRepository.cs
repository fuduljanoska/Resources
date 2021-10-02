using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public class BookingsRepository : IBookingsRepository
    {
        public Task<IEnumerable<Booking>> GetBookingsByResourceAndDatesAsync(DateTime dateFrom, DateTime dateTo, int resourceId)
        {
            return Task.FromResult((IEnumerable<Booking>)new List<Booking>()
            {
                new Booking() { Id = 1, DateFrom = DateTime.Parse("2021-10-02T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-06T00:00:00.000Z"), BookedQuantity = 1, ResourceId = 1 },
                new Booking() { Id = 2, DateFrom = DateTime.Parse("2021-10-03T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-08T00:00:00.000Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking() { Id = 3, DateFrom = DateTime.Parse("2021-10-04T00:00:00.000Z"), DateTo = DateTime.Parse("2021-10-05T00:00:00.000Z"), BookedQuantity = 3, ResourceId = 1 },
            });
        }

        public Task<int> InsertBookingAsync(Booking booking)
        {
            return Task.FromResult(booking.Id);
        }
    }
}
