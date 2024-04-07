using AutoCareHub.Services.Users;
using AutoCareHub.Web.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents user controller.
    /// </summary>
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initialize new instance of <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">the user service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Lists users.
        /// </summary>
        /// <returns>the list users view</returns>
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
