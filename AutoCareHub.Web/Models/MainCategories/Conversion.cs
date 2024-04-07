using AutoCareHub.Services.MainCategories;
using ENTITIES = AutoCareHub.Data.Models;
using WEB_SUB_CATEGORIES = AutoCareHub.Web.Models.SubCategories;

namespace AutoCareHub.Web.Models.MainCategories
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Converts a entity main category to web main category.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web main category</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static MainCategoryViewModel ConvertMainCategory(ENTITIES.MainCategory source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            MainCategoryViewModel target = new MainCategoryViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                SubCategories = source.SubCategories
                    .Select(WEB_SUB_CATEGORIES.Conversion.ConvertSubCategory)
                    .ToList(),
            };

            return target;
        }

        /// <summary>
        /// Converts a entity select main category to web select main category.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web select main category</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SelectMainCategory ConvertSelectMainCategory(ENTITIES.MainCategory source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            SelectMainCategory target = new SelectMainCategory()
            {
                Id = source.Id,
                Name = source.Name,
                IsSelected = false,
            };

            return target;
        }
    }
}
