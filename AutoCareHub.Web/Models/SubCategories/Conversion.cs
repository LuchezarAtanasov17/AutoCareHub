using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.SubCategories
{
    public class Conversion
    {
        public static SubCategoryViewModel ConvertSubCategory(ENTITIES.SubCategory source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            SubCategoryViewModel target = new SubCategoryViewModel()
            {
                MainCategoryId = source.MainCategoryId,
                Name = source.Name,
            };

            return target;
        }
    }
}
