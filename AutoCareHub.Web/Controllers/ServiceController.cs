﻿using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Services.Users;
using AutoCareHub.Web.Model.Services;
using AutoCareHub.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;

namespace AutoCareHub.Web.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var serviceServices = await _serviceService
                .ListServicesAsync();

            serviceServices = serviceServices
                .Where(x => x.UserId != Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                .ToList();

            var services = serviceServices
                .Select(Conversion.ConvertService)
                .ToList();

            return View(services);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var serviceServices = await _serviceService.ListServicesAsync(userId);

            var services = serviceServices
                .Select(Conversion.ConvertService)
                .ToList();

            return View("List", services);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromRoute]
            Guid id)
        {
            var serviceService = await _serviceService.GetServiceAsync(id);

            var service = Conversion.ConvertService(serviceService);

            return View("Details", service);
        }

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
            if (request.OpenTime == request.CloseTime || DateTime.Parse(request.OpenTime.ToString()) < DateTime.Parse(request.CloseTime.ToString()))
            {
                ModelState.AddModelError(nameof(request.CloseTime), "You should select correct open and close times.");
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            }

            request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            request.MainCategoryIds = request.MainCategories
                .Where(x => x.IsSelected)
                .Select(x => x.Id)
                .ToList();

            await _serviceService.CreateServiceAsync(request);

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var service = await _serviceService.GetServiceAsync(id);
            var mainCategories = await _mainCategoryService.ListMainCategoriesAsync();

            var model = new UpdateServiceRequest()
            {
                Id = service.Id,
                Location = service.Location,
                Description = service.Description,
                Name = service.Name,
                OpenTime = service.OpenTime,
                CloseTime = service.CloseTime,
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
            if (request.OpenTime == request.CloseTime)
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

        public async Task<IActionResult> Delete(
          [FromRoute]
            Guid id)
        {
            await _serviceService.DeleteServiceAsync(id);

            return RedirectToAction(nameof(Mine));
        }
    }
}
