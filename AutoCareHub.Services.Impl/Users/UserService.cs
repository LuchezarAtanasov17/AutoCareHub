using AutoCareHub.Data;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Users;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Users
{
    /// <summary>
    /// Represents a user service.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly AutoCareHubDbContext _context;

        /// <summary>
        /// Initialize a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="context">the context</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public async Task<List<ENTITIES.User>> ListUsersAsync()
        {
            try
            {
                var users = await _context.Users
                    .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving users.", ex);
            }
        }
    }
}
