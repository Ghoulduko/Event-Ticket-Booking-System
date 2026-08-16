using Booking.Core.Database;
using Booking.Core.Entities;
using Booking.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.Core.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly TicketBookingDbContext _context;
    private readonly DbSet<User> _users;

    public UserRepository(TicketBookingDbContext context) : base(context)
    {
        _context = context;
        _users = _context.Users;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _users.SingleOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _users.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _users.ToListAsync();
    }
}