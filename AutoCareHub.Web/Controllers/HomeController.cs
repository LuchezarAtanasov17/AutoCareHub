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

namespace AutoCareHub.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceService _serviceService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IUserService _userService;
        private readonly ISubCategoryService _subCategoryService;

        public HomeController(ILogger<HomeController> logger,
            IServiceService serviceService, 
            IMainCategoryService mainCategoryService, 
            IUserService userService,
            ISubCategoryService subCategoryService)
        {
            _logger = logger;
            _serviceService = serviceService;
            _mainCategoryService = mainCategoryService;
            _userService = userService;
            _subCategoryService = subCategoryService;
        }

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
