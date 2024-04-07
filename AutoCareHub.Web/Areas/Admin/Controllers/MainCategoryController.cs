using AutoCareHub.Services.MainCategories;
using AutoCareHub.Web.Models.MainCategories;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents main category controller.
    /// </summary>
    public class MainCategoryController : BaseController
    {
        private readonly IMainCategoryService _mainCategoryService;

        /// <summary>
        /// Initialize new instance of <see cref="MainCategoryController"/> class.
        /// </summary>
        /// <param name="mainCategoryService">the main category service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public MainCategoryController(
           IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));
        }

        /// <summary>
        /// Lists main categories.
        /// </summary>
        /// <returns>the list main categories view</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entityMainCategories = await _mainCategoryService.ListMainCategoriesAsync();

            List<MainCategoryViewModel> mainCategories = entityMainCategories
                .Select(Conversion.ConvertMainCategory)
                .ToList();

            return View("List", mainCategories);
        }

        /// <summary>
        /// Creates create main category request.
        /// </summary>
        /// <returns>the create main category view</returns>
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMainCategoryRequest();

            return View(model);
        }

        /// <summary>
        /// Creates main category.
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>the list main categories view</returns>
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateMainCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _mainCategoryService.CreateMainCategoryAsync(request);

            return RedirectToAction(nameof(List));
        }

        /// <summary>
        /// Deletes a specified main category.
        /// </summary>
        /// <param name="id">the main category ID</param>
        /// <returns>the list main categories view</returns>
        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            await _mainCategoryService.DeleteMainCategoryAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
