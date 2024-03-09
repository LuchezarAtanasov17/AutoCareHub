using AutoCareHub.Services.MainCategories;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.MainCategories
{
    internal class Conversion
    {
        #region Request To Entity

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
