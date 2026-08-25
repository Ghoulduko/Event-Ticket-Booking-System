using Booking.Application.Dtos.Reservation;
using Booking.Core.Models;

namespace Booking.Application.Interfaces.ReservationInterfaces;

public interface IReservationService
{
    Task<Result<ReservationDto>> Create(CreateReservationDto request);
    Task<Result<ReservationDto>> GetReservationById(int reservationId);
    Task<Result<ReservationDto>> GetReservationByUserEmail(string email);
    Task<IEnumerable<ReservationDto>> GetEventReservations(int eventId);
}