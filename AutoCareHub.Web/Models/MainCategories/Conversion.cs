using AutoCareHub.Services.MainCategories;
using ENTITIES = AutoCareHub.Data.Models;
using WEB_SUB_CATEGORIES = AutoCareHub.Web.Models.SubCategories;

namespace AutoCareHub.Web.Models.MainCategories
{
   public class Conversion
    {
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
