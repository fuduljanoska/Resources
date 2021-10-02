using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.API.Repositories
{
    public interface IBookingsRepository
    {
        Task<IEnumerable<Booking>> GetBookingsByResourceAndDatesAsync(DateTime dateFrom, DateTime dateTo, int resourceId);
        Task<int> InsertBookingAsync(Booking booking);
    }
}
