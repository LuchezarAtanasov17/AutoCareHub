using AutoCareHub.Web.Models.SubCategories;

namespace AutoCareHub.Web.Models.MainCategories
{
    public class MainCategoryViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<SubCategoryViewModel> SubCategories { get; set; }
    }
}
