using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.SubCategories;
using AutoCareHub.Web.Models.SubCategories;
using Microsoft.AspNetCore.Mvc;
using MAIN_CATEGORIES = AutoCareHub.Web.Models.MainCategories;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMainCategoryService _mainCategoryService;

        public SubCategoryController(
           ISubCategoryService subCategoryService, IMainCategoryService mainCategoryService)
        {
            _subCategoryService = subCategoryService ?? throw new ArgumentNullException(nameof(subCategoryService));
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entitySubCategories = await _subCategoryService.ListSubCategoriesAsync();

            List<SubCategoryViewModel> subCategories = entitySubCategories
                .Select(Conversion.ConvertSubCategory)
                .ToList();

            return View("List", subCategories);
        }

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

        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            await _subCategoryService.DeleteSubCategoryAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
