using AutoMapper;
using Resources.API.DTOs;
using Resources.API.Models;

namespace Resources.API.MapperProfiles
{
    public class BookingProfiles : Profile
    {
        public BookingProfiles()
        {
            CreateMap<BookingPostDto, Booking>();
        }
    }
}
