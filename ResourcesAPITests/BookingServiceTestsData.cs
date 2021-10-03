using Resources.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourcesAPITests
{
    public static class BookingServiceTestsData
    {
        public static Resource GetResourceForTesting()
        {
            return new Resource()
            {
                Id = 1,
                Name = "Test resource",
                Quantity = 10
            };
        }
        public static IEnumerable<object[]> GetTestData()
        {
            var resource = GetResourceForTesting();
            
            var testData = new List<object[]>
            {
                //(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
                new object[] { new DateTime(2021, 1, 1), new  DateTime(2021, 1, 2), 5, resource.Id},
                new object[] { new DateTime(2021, 1, 3), new  DateTime(2021, 1, 4), 10, resource.Id},
                new object[] { new DateTime(2021, 1, 6), new  DateTime(2021, 1, 7), 2, resource.Id }
            };

            return testData;
        }

        public static List<Booking> GetTestBookings_NotAvailable()
        {
            var resource = GetResourceForTesting();

            var bookings = new List<Booking>
            {
                //(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 10), BookedQuantity = 2, ResourceId = resource.Id},
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 3), BookedQuantity = 3, ResourceId = resource.Id},
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 8), BookedQuantity = 5, ResourceId = resource.Id}
            };

            return bookings;
        }

        public static List<Booking> GetTestBookings_SomeAvailable()
        {
            var resource = GetResourceForTesting();

            var bookings = new List<Booking>
            {
                //(DateTime dateFrom, DateTime dateTo, int bookedQuantity, int resourceId)
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 10), BookedQuantity = 5, ResourceId = resource.Id},
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 3), BookedQuantity = 3, ResourceId = resource.Id},
                new Booking { DateFrom = new DateTime(2021, 1, 1), DateTo = new  DateTime(2021, 1, 8), BookedQuantity = 1, ResourceId = resource.Id}
            };

            return bookings;
        }
    }
}
