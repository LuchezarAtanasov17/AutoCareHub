using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Users
{
    /// <summary>
    /// Provides access to users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Lists users.
        /// </summary>
        /// <returns>a collection of users</returns>
        Task<List<User>> ListUsersAsync();
    }
}
