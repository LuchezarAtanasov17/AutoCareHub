using AutoCareHub.Services.Users;
using AutoCareHub.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var userServices = await _userService.ListUsersAsync();

            var users = userServices
                .Select(Conversion.ConvertUser)
                .ToList();

            return View(users);
        }
    }
}
