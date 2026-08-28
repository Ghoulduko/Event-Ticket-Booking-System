using AutoMapper;
using Booking.Application.Dtos.Event;
using Booking.Application.Dtos.Reservation;
using Booking.Application.Dtos.Seat;
using Booking.Application.Dtos.User;
using Booking.Core.Entities;

namespace Booking.Application.Mapper.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        // User Mapping
        CreateMap<UserDto, User>().ReverseMap();
        // Seat Mapping
        CreateMap<SeatDto, Seat>().ReverseMap();
        // Event Mapping
        CreateMap<EventDto, Event>().ReverseMap();
        // Reservation Mapping
        CreateMap<ReservationDto, Reservation>().ReverseMap();
    }
}