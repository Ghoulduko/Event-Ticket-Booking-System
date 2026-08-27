using Booking.Core.Entities;

namespace Booking.Core.Interfaces;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserById(int userId);
    Task<User?> GetUserByEmail(string email);
    Task<IEnumerable<User>> GetAllUsers();
}