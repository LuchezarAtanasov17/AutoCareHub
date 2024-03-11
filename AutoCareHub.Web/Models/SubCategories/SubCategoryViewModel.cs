using AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.SubCategories
{
    public class SubCategoryViewModel
    {
        public Guid MainCategoryId { get; set; }

        public string Name { get; set; } = null!;
    }
}
