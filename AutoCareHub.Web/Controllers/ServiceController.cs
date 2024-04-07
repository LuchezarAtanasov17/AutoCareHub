using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Comments;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Services.Users;
using AutoCareHub.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;

namespace AutoCareHub.Web.Controllers
{
    /// <summary>
    /// Represents a service controller.
    /// </summary>
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IUserService _userService;
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IWebHostEnvironment _hostEnvironment;

        /// <summary>
        /// Initialize new instance of <see cref="ServiceController"/> class.
        /// </summary>
        /// <param name="serviceService"></param>
        /// <param name="userService"></param>
        /// <param name="categoryService"></param>
        /// <param name="hostEnvironment"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceController(
            IServiceService serviceService,
            IUserService userService,
            IMainCategoryService mainCategoryService,
            IWebHostEnvironment hostEnvironment)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));
            _hostEnvironment = hostEnvironment ?? throw new ArgumentNullException(nameof(hostEnvironment));
        }

        /// <summary>
        /// Lists the services.
        /// </summary>
        /// <param name="query">the query</param>
        /// <returns>the list services view</returns>
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] AllServicesQueryModel query)
        {
            var entityServices = await _serviceService
                .ListServicesAsync(
                userId: Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value),
                category: query.MainCategory,
                city: query.City,
                allOrMineOption: query.AllOrMineOption);

            var entityMainCategories = await _mainCategoryService
                .ListMainCategoriesAsync();

            query.Services = entityServices
                .Where(x=>x.IsApproved == true)
                .Select(Conversion.ConvertService)
                .ToList();
            query.MainCategories = entityMainCategories
                .Select(MAIN_CATEGORIES.Conversion.ConvertMainCategory)
                .Select(x => x.Name)
                .ToList();
            query.Cities = query.Services
                .Select(x => x.City)
                .ToList();

            return View(query);
        }

        /// <summary>
        /// Gets a service with specified ID.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <returns>a details of the service view</returns>
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute]
            Guid id)
        {
            var serviceService = await _serviceService.GetServiceAsync(id);

            ServiceViewModel service = Conversion.ConvertService(serviceService);

            if (ModelState.IsValid)
            {
                service.CreateAppointmentRequest = new CreateAppointmentRequest()
                {
                    ServiceId = id,
                    ServiceMainCategories = service.MainCategories
                        .Select(Conversion.ConvertMainCategoryViewModelToServiceMainCategory)
                        .ToList(),
                };
            }
            else
            {
                service.CreateAppointmentRequest.ServiceMainCategories = service.MainCategories
                                                                        .Select(Conversion.ConvertMainCategoryViewModelToServiceMainCategory)
                                                                        .ToList();
            }

            service.CreateCommentRequest = new CreateCommentRequest()
            {
                ServiceId = id,
            };

            return View("Details", service);
        }

        /// <summary>
        /// Creates a create service request.
        /// </summary>
        /// <returns>the create service view</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var mainCategories = await _mainCategoryService
                .ListMainCategoriesAsync();

            var model = new CreateServiceRequest()
            {
                MainCategories = mainCategories
                    .Select(MAIN_CATEGORIES.Conversion.ConvertSelectMainCategory)
                    .ToList(),
            };

            return View(model);
        }

        /// <summary>
        /// Creates a service.
        /// </summary>
        /// <param name="request">the request for creating a service</param>
        /// <returns>the list services view</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateServiceRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.MainCategories.Where(x => x.IsSelected == true).ToList().Count < 1)
            {
                ModelState.AddModelError(nameof(request.MainCategories), "You should select at least one category.");
            }
            if (request.OpenTime == request.CloseTime || DateTime.Parse(request.OpenTime.ToString()) > DateTime.Parse(request.CloseTime.ToString()))
            {
                ModelState.AddModelError(nameof(request.CloseTime), "You should select correct open and close times.");
            }

            request.MainCategoryIds = request.MainCategories
                .Where(x => x.IsSelected)
                .Select(x => x.Id)
                .ToList();

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _serviceService.CreateServiceAsync(request);

            return RedirectToAction(nameof(List));
        }

        /// <summary>
        /// Creates an update service request.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <returns>update service view</returns>
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var service = await _serviceService.GetServiceAsync(id);
            var mainCategories = await _mainCategoryService.ListMainCategoriesAsync();

            var model = new UpdateServiceRequest()
            {
                Id = service.Id,
                City = service.City,
                Address = service.Address,
                Description = service.Description,
                Name = service.Name,
                OpenTime = service.OpenTime.ToString(),
                CloseTime = service.CloseTime.ToString(),
                SelectMainCategory = mainCategories
                    .Select(x => MAIN_CATEGORIES.Conversion.ConvertSelectMainCategory(x))
                    .ToList()
            };

            foreach (var category in model.SelectMainCategory)
            {
                if (service.MainCategoryServices.Select(x => x.MainCategory).Select(x => x.Id).Contains(category.Id))
                {
                    category.IsSelected = true;
                }
            }

            return View(model);
        }

        /// <summary>
        /// Updates a specified service.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <param name="request">the request for updating the service</param>
        /// <returns>the details of the service view</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateServiceRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.SelectMainCategory.Where(x => x.IsSelected == true).ToList().Count < 1)
            {
                ModelState.AddModelError(nameof(request.SelectMainCategory), "You should select at least one category.");
            }
            if (request.OpenTime == request.CloseTime || DateTime.Parse(request.OpenTime) > DateTime.Parse(request.CloseTime))
            {
                ModelState.AddModelError(nameof(request.CloseTime), "You should select correct open and close times.");
            }
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _serviceService.UpdateServiceAsync(id, request);

            return RedirectToAction(nameof(Get), new { Id = id });
        }

        /// <summary>
        /// Deletes a specified service.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <returns>the list services view</returns>
        public async Task<IActionResult> Delete(
          [FromRoute]
            Guid id)
        {
            await _serviceService.DeleteServiceAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
