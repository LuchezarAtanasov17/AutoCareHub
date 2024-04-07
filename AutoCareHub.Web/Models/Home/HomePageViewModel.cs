using AutoCareHub.Web.Models.MainCategories;
using AutoCareHub.Web.Models.Services;
using AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Home
{
    /// <summary>
    /// Represents a home page view model.
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// Gets or sets the sub categories count.
        /// </summary>
        public int SubCategoriesCount { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public List<ServiceViewModel> Services { get; set; }

        /// <summary>
        /// Gets or sets the main categories.
        /// </summary>
        public List<MainCategoryViewModel> MainCategories { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public List<UserViewModel> Users { get; set; }
    }
}
