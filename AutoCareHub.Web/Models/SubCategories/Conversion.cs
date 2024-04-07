using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.SubCategories
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Converts a entity sub category to web sub category.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web sub category</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SubCategoryViewModel ConvertSubCategory(ENTITIES.SubCategory source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            SubCategoryViewModel target = new SubCategoryViewModel()
            {
                Id = source.Id,
                MainCategoryId = source.MainCategoryId,
                Name = source.Name,
                MainCategoryName = source.MainCategory.Name,
            };

            return target;
        }
    }
}
