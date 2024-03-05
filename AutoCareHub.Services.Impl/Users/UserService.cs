using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Users;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.Users
{
    public class UserService : IUserService
    {
        private readonly AutoCareHubDbContext _context;

        public UserService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<User>> ListUsersAsync()
        {
            var users = await _context.Users
                .ToListAsync();

            return users;
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new ObjectNotFoundException(nameof(user));
            }

            return user;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null) 
            {
                throw new ObjectNotFoundException(nameof(user));
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
