using Moq;
using Moq.AutoMock;
using Resources.API.Models;
using Resources.API.Repositories;
using Resources.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ResourcesAPITests
{
    public class BookingsServiceTests
    {
        private AutoMocker _autoMocker = new AutoMocker();
        Mock<IBookingsRepository> bookingsRepository = new Mock<IBookingsRepository>();
        Mock<IResourcesRepository> resourceRepository = new Mock<IResourcesRepository>();

        private void CheckBookingConflictsAsync_Setup()
        {
            _autoMocker.Use(bookingsRepository);
            _autoMocker.Use(resourceRepository);
            _autoMocker.Use("admin@admin.com");
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public async Task CheckBookingConflictsAsync_ShouldPass(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
        {
            CheckBookingConflictsAsync_Setup();
            bookingsRepository.Setup(x => x.GetBookingsByResourceAndDates(dateFrom, dateTo, resourceId)).Returns(new List<Booking>());
            
            var resource = BookingServiceTestsData.GetResourceForTesting();
            resourceRepository.Setup(x => x.GetResourceAsync(resourceId)).Returns(new ValueTask<Resource>(resource));
            
            BookingsService bookingsService = _autoMocker.CreateInstance<BookingsService>();

            var result = await bookingsService.CheckBookingConflictsAsync(new Booking() { DateFrom = dateFrom, DateTo = dateTo, BookedQuantity = bookedQuantity, ResourceId = resourceId });

            Assert.True(result.IsSuccess);
            Assert.Equal(result.Message, $"Resource {resource.Name} is available!");
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public async Task CheckBookingConflictsAsync_ShouldFail_NotAvailable(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
        {
            CheckBookingConflictsAsync_Setup();
            bookingsRepository.Setup(x => x.GetBookingsByResourceAndDates(dateFrom, dateTo, resourceId)).Returns(BookingServiceTestsData.GetTestBookings_NotAvailable);
            
            var resource = BookingServiceTestsData.GetResourceForTesting();
            resourceRepository.Setup(x => x.GetResourceAsync(resourceId)).Returns(new ValueTask<Resource>(resource));

            BookingsService bookingsService = _autoMocker.CreateInstance<BookingsService>();

            var result = await bookingsService.CheckBookingConflictsAsync(new Booking() { DateFrom = dateFrom, DateTo = dateTo, BookedQuantity = bookedQuantity, ResourceId = resourceId });

            Assert.False(result.IsSuccess);
            Assert.Equal(result.Message, $"Resource {resource.Name} is unavailable!");
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public async Task CheckBookingConflictsAsync_ShouldFail_SomeAvailable(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
        {
            CheckBookingConflictsAsync_Setup();
            bookingsRepository.Setup(x => x.GetBookingsByResourceAndDates(dateFrom, dateTo, resourceId)).Returns(BookingServiceTestsData.GetTestBookings_SomeAvailable);

            var resource = BookingServiceTestsData.GetResourceForTesting();
            resourceRepository.Setup(x => x.GetResourceAsync(resourceId)).Returns(new ValueTask<Resource>(resource));

            BookingsService bookingsService = _autoMocker.CreateInstance<BookingsService>();

            var result = await bookingsService.CheckBookingConflictsAsync(new Booking() { DateFrom = dateFrom, DateTo = dateTo, BookedQuantity = bookedQuantity, ResourceId = resourceId });
            var availableQuantity = resource.Quantity - BookingServiceTestsData.GetTestBookings_SomeAvailable().Sum(x => x.BookedQuantity);

            Assert.False(result.IsSuccess);
            Assert.Equal(result.Message, $"Required quantity of {resource.Name} is unavailable! There are only {availableQuantity} left!");
        }

        public static IEnumerable<object[]> GetData()
        {
            return BookingServiceTestsData.GetTestData();
        }
    }
}
