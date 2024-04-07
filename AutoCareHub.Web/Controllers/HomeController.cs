using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Services.Users;
using AutoCareHub.Web.Models;
using AutoCareHub.Web.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SERVICES = AutoCareHub.Web.Models.Services;
using MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;
using USERS = AutoCareHub.Web.Models.Users;
using AutoCareHub.Services.SubCategories;
using Microsoft.AspNetCore.Diagnostics;
using AutoCareHub.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace AutoCareHub.Web.Controllers
{
    /// <summary>
    /// Represents a home controller.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IUserService _userService;
        private readonly ISubCategoryService _subCategoryService;

        /// <summary>
        /// Initialize new instance of <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="serviceService">the service service</param>
        /// <param name="mainCategoryService">the main category service</param>
        /// <param name="userService">the user service</param>
        /// <param name="subCategoryService">the sub category service</param>
        public HomeController(
            IServiceService serviceService,
            IMainCategoryService mainCategoryService,
            IUserService userService,
            ISubCategoryService subCategoryService)
        {
            _serviceService = serviceService;
            _mainCategoryService = mainCategoryService;
            _userService = userService;
            _subCategoryService = subCategoryService;
        }

        /// <summary>
        /// Loads the home page.
        /// </summary>
        /// <returns>the home page view</returns>
        public async Task<IActionResult> Index()
        {
            var entityServices = await _serviceService.ListServicesAsync();
            var entityMainCategories = await _mainCategoryService.ListMainCategoriesAsync();
            var entityUsers = await _userService.ListUsersAsync();

            HomePageViewModel model = new HomePageViewModel()
            {
                SubCategoriesCount = await _subCategoryService.Count(),
                Services = entityServices
                    .Where(x => x.IsApproved == true)
                    .Select(SERVICES.Conversion.ConvertService)
                    .ToList(),
                MainCategories = entityMainCategories
                    .Select(MAIN_CATEGORIES.Conversion.ConvertMainCategory)
                    .ToList(),
                Users = entityUsers
                    .Select(USERS.Conversion.ConvertUser)
                    .ToList(),
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var statusCode = exception is not null
                ? Helper.ProcessException(exception)
                : StatusCodes.Status500InternalServerError;

            var viewModel = new ErrorViewModel
            {
                StatusCode = statusCode,
                Message = exception?.Message
            };

            return View(viewModel);
        }
    }
}
