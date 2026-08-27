using AutoMapper;
using Booking.Application.Dtos.Event;
using Booking.Application.Interfaces.EventInterfaces;
using Booking.Application.Services.SeatS;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Booking.Core.Models;
using Microsoft.Extensions.Logging;

namespace Booking.Application.Services.EventS;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<SeatService> _logger;
    
    public EventService(IEventRepository eventRepository, IMapper mapper, ILogger<SeatService> logger)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Result<EventDto>> Create(AddEventDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return new Result<EventDto>
            {
                Success = false,
                Message = "Event name cannot be empty."
            };
        }
        var eventExists = await _eventRepository.EventExists(request.Name);
        if (eventExists)
        {
            return new Result<EventDto>
            {
                Success = false,
                Message = "Event with that name already exists."
            };
        }

        if (request.EventDate < DateTime.UtcNow)
        {
            return new Result<EventDto>
            {
                Success = false,
                Message = "Event date must be in the future."
            };
        }

        var newEvent = new Event
        {
            Name = request.Name,
            Description = request.Description,
            EventDate = request.EventDate,
            CreatedAt = DateTime.UtcNow,
        };
        
        await _eventRepository.Create(newEvent);

        return new Result<EventDto>
        {
            Success = true,
            Message = "Event created successfully"
        };
    }

    public async Task<Result<EventDto>> GetEventById(int eventId)
    {
        var eventById = await _eventRepository.GetEventById(eventId);
        if (eventById is null)
        {
            return new Result<EventDto>
            {
                Success = false,
                Message = "Event with that id does not exist."
            };
        }

        return new Result<EventDto>
        {
            Success = true,
            Message = "Event found.",
            Data = _mapper.Map<EventDto>(eventById),
        };
    }

    public async Task<Result<EventDto>> GetEventByName(string eventName)
    {
        var eventByName = await _eventRepository.GetEventByName(eventName);
        if (eventByName is null)
        {
            return new Result<EventDto>
            {
                Success = false,
                Message = "Event with that name does not exist."
            };
        }

        return new Result<EventDto>
        {
            Success = true,
            Message = "Event found.",
            Data = _mapper.Map<EventDto>(eventByName),
        };
    }

    public async Task<IEnumerable<EventDto>> GetAllEvents()
    {
        var allEvents = await _eventRepository.GetAllEvents();
        return _mapper.Map<IEnumerable<EventDto>>(allEvents);
    }
}