using AutoCareHub.Services.SubCategories;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.SubCategories
{
    internal class Conversion
    {
        #region Request To Entity

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
