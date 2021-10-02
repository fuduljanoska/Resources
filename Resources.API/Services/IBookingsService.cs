using Resources.API.Models;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public interface IBookingsService
    {
        Task<BookingResult> BookResourceAsync(Booking booking);
        Task<BookingResult> CheckBookingConflictsAsync(Booking booking);
    }
}
