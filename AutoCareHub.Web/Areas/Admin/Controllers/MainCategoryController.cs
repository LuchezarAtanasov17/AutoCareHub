using AutoCareHub.Services.MainCategories;
using AutoCareHub.Web.Models.MainCategories;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class MainCategoryController : BaseController
    {
        private readonly IMainCategoryService _mainCategoryService;

        public MainCategoryController(
           IMainCategoryService mainCategoryService)
        {
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entityMainCategories = await _mainCategoryService.ListMainCategoriesAsync();

            List<MainCategoryViewModel> mainCategories = entityMainCategories
                .Select(Conversion.ConvertMainCategory)
                .ToList();

            return View("List", mainCategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMainCategoryRequest();

            return View(model);
        }

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

        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            await _mainCategoryService.DeleteMainCategoryAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
