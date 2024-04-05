using AutoCareHub.Data;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Users;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Users
{
    public class UserService : IUserService
    {
        private readonly AutoCareHubDbContext _context;

        public UserService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ENTITIES.User>> ListUsersAsync()
        {
            try
            {
                var users = await _context.Users
                    .ToListAsync();

                return users;
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while retrieving users.");
            }
        }
    }
}
