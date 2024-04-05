using AutoCareHub.Web.Models.MainCategories;
using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Home
{
    public class HomePageViewModel
    {
        public int SubCategoriesCount { get; set; }

        public List<ServiceViewModel> Services { get; set; }

        public List<MainCategoryViewModel> MainCategories { get; set; }

        public List<UserViewModel> Users { get; set; }
    }
}
