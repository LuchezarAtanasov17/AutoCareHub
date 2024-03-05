using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.MainCategories
{
    public interface IMainCategoryService
    {
        Task<List<MainCategory>> ListMainCategoriesAsync(Guid? serviceId = null);

        Task<MainCategory> GetMainCategoryAsync(Guid id);

        Task CreateMainCategoryAsync(CreateMainCategoryRequest request);

        Task DeleteMainCategoryAsync(Guid id);
    }
}
