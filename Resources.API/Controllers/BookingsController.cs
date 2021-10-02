using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resources.API.DTOs;
using Resources.API.Models;
using Resources.API.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Resources.API.Controllers
{
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;
        private readonly IMapper _mapper;

        public BookingsController(IBookingsService bookingsService, IMapper mapper)
        {
            _bookingsService = bookingsService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("bookResource")]
        public async Task<ActionResult<BookingResult>> BookResourceAsync([FromBody][Required]BookingPostDto bookingPostDto)
        {
            if (!ValidateModel(bookingPostDto, out var actionResult))
            {
                return actionResult;
            }

            var booking = _mapper.Map<BookingPostDto, Booking>(bookingPostDto);
            try
            {
                var result = await _bookingsService.BookResourceAsync(booking);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message,
                    null,
                    (int)HttpStatusCode.InternalServerError,
                    "Exception was thrown bookings read.");
            }
        }

        [HttpPost]
        [Route("checkBookingConflicts")]
        public async Task<ActionResult> CheckBookingConflictsAsync([FromBody][Required] BookingPostDto bookingPostDto)
        {
            if(!ValidateModel(bookingPostDto, out var actionResult))
            {
                return actionResult;
            }

            var booking = _mapper.Map<BookingPostDto, Booking>(bookingPostDto);
            try
            {
                var result = await _bookingsService.CheckBookingConflictsAsync(booking);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message,
                    null,
                    (int)HttpStatusCode.InternalServerError,
                    "Exception was thrown during bookings read.");
            }
        }

        private bool ValidateModel(BookingPostDto bookingPostDto, out ActionResult actionResult)
        {
            if (!ModelState.IsValid)
            {
                actionResult = BadRequest(ModelState);

                return false;
            }

            if (bookingPostDto.DateTo <= bookingPostDto.DateFrom)
            {
                actionResult = BadRequest(new { ErrorMessage = "DateTo cannot be smaller or equal to DateFrom" });

                return false;
            }

            actionResult = null;

            return true;
        }
    }
}
