using Resources.API.Models;
using Resources.API.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resources.API.Services
{
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _bookingRepository;
        private readonly IResourcesRepository _resourcesRepository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly string _emailRecipient;
        private static SemaphoreSlim _bookingsSemaphore = new SemaphoreSlim(1, 1);

        public BookingsService(IBookingsRepository bookingRepository,
            IResourcesRepository resourcesRepository,
            IEmailSenderService emailSenderService,
            string emailRecipient)
        {
            _bookingRepository = bookingRepository;
            _resourcesRepository = resourcesRepository;
            _emailSenderService = emailSenderService;
            _emailRecipient = emailRecipient;
        }

        public async Task<BookingResult> BookResourceAsync(Booking booking)
        {
            var resource = await _resourcesRepository.GetResourceAsync(booking.ResourceId);
            await _bookingsSemaphore.WaitAsync();
            BookingResult bookingResult;
            try
            {
                bookingResult = await CheckBookingConflictsAsync(booking, resource);
                if (bookingResult.IsSuccess)
                {
                    await _bookingRepository.InsertBookingAsync(booking);
                }
            }
            finally
            {
                _bookingsSemaphore.Release();
            }

            // Since the result of sending email operation is not important in context of the request,
            // in real world this should be queued in a background service queue, and free the request thread.
            // For the purpose of this application it's enough if we just fire it in a background thread,
            // and do not wait for the result.
            if (bookingResult.IsSuccess)
            {
                _ = Task.Run(() => _emailSenderService.SendEmailAsync(
                    new EmailModel()
                    {
                        To = _emailRecipient,
                        Subject = "Booking created",
                        Body = $"EMAIL SENT TO { _emailRecipient } FOR CREATED BOOKING WITH ID { booking.Id }"
                    }));
            }

            return bookingResult;
        }

        public async Task<BookingResult> CheckBookingConflictsAsync(Booking booking, Resource resource)
        {
            var existingResourceBookings = 
                await _bookingRepository.GetBookingsByResourceAndDatesAsync(booking.DateFrom, booking.DateTo, booking.ResourceId);
            var totalBookedQuantity = existingResourceBookings.Sum(x => x.BookedQuantity);
            if(booking.BookedQuantity + totalBookedQuantity > resource.Quantity)
            {
                if (resource.Quantity == totalBookedQuantity)
                {
                    return new BookingResult() { IsSuccess = false, Message = $"Resource {resource.Name} is unavailable!" };
                }

                return new BookingResult() { IsSuccess = false, Message = $"Required quantity of {resource.Name} is unavailable! There are only {resource.Quantity - totalBookedQuantity} left!" };    
            }

            return new BookingResult() { IsSuccess = true, Message = $"Resource {resource.Name} is available!" };
        }
    }
}
