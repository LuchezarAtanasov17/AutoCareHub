using AutoCareHub.Services.SubCategories;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.SubCategories
{
    /// <summary>
    /// Represents a conversion class for converting sub category models.
    /// </summary>
    public class Conversion
    {
        #region Request To Entity

        /// <summary>
        /// Converts the create sub category request to entity sub category.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the entity sub category</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ENTITIES.SubCategory ConvertSubCategory(CreateSubCategoryRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.SubCategory()
            {
                Name = source.Name,
                MainCategoryId = source.MainCategoryId,
            };

            return target;
        }

        #endregion
    }
}
