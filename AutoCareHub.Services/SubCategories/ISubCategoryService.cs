using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.SubCategories
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> ListSubCategoriesAsync(Guid? mainCategoryId = null);

        Task CreateSubCategoryAsync(CreateSubCategoryRequest request);

        Task DeleteSubCategoryAsync(Guid id);

        Task<int> Count();
    }
}
