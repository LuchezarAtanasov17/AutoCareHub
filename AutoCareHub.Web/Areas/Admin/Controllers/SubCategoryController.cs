using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.SubCategories;
using AutoCareHub.Web.Models.SubCategories;
using Microsoft.AspNetCore.Mvc;
using MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents sub category controller.
    /// </summary>
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;

        /// <summary>
        /// Initialize new instance of <see cref="SubCategoryController"/> class.
        /// </summary>
        /// <param name="subCategoryService">the sub category service</param>
        /// <param name="mainCategoryService">the main category service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public SubCategoryController(
           ISubCategoryService subCategoryService, IMainCategoryService mainCategoryService)
        {
            _subCategoryService = subCategoryService ?? throw new ArgumentNullException(nameof(subCategoryService));
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));
        }

        /// <summary>
        /// Lists sub categories.
        /// </summary>
        /// <returns>the list sub categories view</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entitySubCategories = await _subCategoryService.ListSubCategoriesAsync();

            List<SubCategoryViewModel> subCategories = entitySubCategories
                .Select(Conversion.ConvertSubCategory)
                .ToList();

            return View("List", subCategories);
        }

        /// <summary>
        /// Creates a create sub category request
        /// </summary>
        /// <returns>the create sub category view</returns>
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var mainCategories = await _mainCategoryService.ListMainCategoriesAsync();
            var model = new CreateSubCategoryRequest()
            {
                MainCategories = mainCategories
                .Select(MAIN_CATEGORIES.Conversion.ConvertSelectMainCategory)
                .ToList(),
            };

            return View(model);
        }

        /// <summary>
        /// Creates sub category.
        /// </summary>
        /// <param name="request">the request</param>
        /// <returns>the list sub categories view</returns>
        [HttpPost]
        public async Task<IActionResult> Create(
            CreateSubCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _subCategoryService.CreateSubCategoryAsync(request);

            return RedirectToAction(nameof(List));
        }

        /// <summary>
        /// Deletes sub category with specified ID.
        /// </summary>
        /// <param name="id">the sub category ID</param>
        /// <returns>the list sub categories view</returns>
        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            await _subCategoryService.DeleteSubCategoryAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
