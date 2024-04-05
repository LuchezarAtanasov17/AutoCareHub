using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> ListUsersAsync();
    }
}
