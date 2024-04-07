using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.SubCategories
{
    /// <summary>
    /// Provides access to sub category service.
    /// </summary>
    public interface ISubCategoryService
    {
        /// <summary>
        /// Lists sub cateogries.
        /// </summary>
        /// <param name="mainCategoryId">the main category ID</param>
        /// <returns>a collection of sub categories</returns>
        Task<List<SubCategory>> ListSubCategoriesAsync(Guid? mainCategoryId = null);

        /// <summary>
        /// Creates sub category
        /// </summary>
        /// <param name="request">the request for creating sub category</param>
        Task CreateSubCategoryAsync(CreateSubCategoryRequest request);

        /// <summary>
        /// Deletes a specified sub category.
        /// </summary>
        /// <param name="id">the sub category ID</param>
        Task DeleteSubCategoryAsync(Guid id);

        /// <summary>
        /// Counts the sub categories.
        /// </summary>
        /// <returns>the count of sub categories</returns>
        Task<int> Count();
    }
}
