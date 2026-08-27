using AutoMapper;
using Booking.Application.Dtos.Event;
using Booking.Application.Dtos.Seat;
using Booking.Application.Interfaces.SeatInterfaces;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.SeatS;

public class SeatService : ISeatService
{
    private readonly ISeatRepository _seatRepository;
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<SeatService> _logger;
    
    public SeatService(ISeatRepository seatRepository, IEventRepository eventRepository, IMapper mapper, ILogger<SeatService> logger)
    {
        _seatRepository = seatRepository;
        _eventRepository = eventRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Result<SeatDto>> Create(CreateSeatDto request)
    {
        var eventExists = await _eventRepository.GetEventById(request.EventId);
        if (eventExists is null)
            return new Result<SeatDto>
            {
                Success = false,
                Message = "Seat EventId is invalid"
            };


        if (request.Row < 1 || request.Row > 30)
            return new Result<SeatDto>
            {
                Success = false,
                Message = "Seat Row Number is invalid"
            };

        Seat seat = new Seat
        {
            IsAvailable = true,
            Row = request.Row,
            EventId = request.EventId
        };
        
        await _seatRepository.Create(seat);

        return new Result<SeatDto>
        {
            Success = true,
            Message = "Event created successfully"
        };
    }

    public async Task<Result<SeatDto>> GetById(int seatId)
    {
        var seat = await _seatRepository.GetById(seatId);
        if (seat == null)
            return new Result<SeatDto>
            {
                Success = false,
                Message = "No Seat was found with the provided ID"
            };

        return new Result<SeatDto>
        {
            Success = true,
            Data = _mapper.Map<SeatDto>(seat)
        };
    }

    public async Task<IEnumerable<SeatDto>> GetSeatsByEventId(int eventId)
    {
        var allSeats = await _seatRepository.GetSeatsByEventId(eventId);
        return _mapper.Map<List<SeatDto>>(allSeats);
    }
}