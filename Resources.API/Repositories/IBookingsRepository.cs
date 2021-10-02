using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public interface IBookingsRepository
    {
        IEnumerable<Booking> GetBookingsByResourceAndDates(DateTime dateFrom, DateTime dateTo, int resourceId);
        Task<Booking> InsertBookingAsync(Booking booking);
    }
}
