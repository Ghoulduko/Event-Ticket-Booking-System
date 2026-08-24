using AutoMapper;
using Booking.Application.Dtos.Seat;
using Booking.Core.Entities;

namespace Booking.Application.Mapper.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SeatDto, Seat>().ReverseMap();
    }
}