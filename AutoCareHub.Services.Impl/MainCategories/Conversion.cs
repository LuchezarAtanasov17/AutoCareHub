using AutoCareHub.Services.MainCategories;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.MainCategories
{
    /// <summary>
    /// Represents a conversion class for converting main category models.
    /// </summary>
    public class Conversion
    {
        #region Request To Entity

        /// <summary>
        /// Converts create main category request to entity model.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the entity main category</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ENTITIES.MainCategory ConvertMainCategory(CreateMainCategoryRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.MainCategory()
            {
                Name = source.Name,
            };

            return target;
        }

        #endregion
    }
}
