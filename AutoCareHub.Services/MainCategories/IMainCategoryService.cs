using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.MainCategories
{
    /// <summary>
    /// Provides access to main category service.
    /// </summary>
    public interface IMainCategoryService
    {
        /// <summary>
        /// Lists main categories.
        /// </summary>
        /// <param name="serviceId">the service ID</param>
        /// <returns>a collection of main categories</returns>
        Task<List<MainCategory>> ListMainCategoriesAsync(Guid? serviceId = null);

        /// <summary>
        /// Creates main category.
        /// </summary>
        /// <param name="request">the request for creating main category</param>
        Task CreateMainCategoryAsync(CreateMainCategoryRequest request);

        /// <summary>
        /// Deletes a specified main category.
        /// </summary>
        /// <param name="id">the category ID</param>
        Task DeleteMainCategoryAsync(Guid id);
    }
}
