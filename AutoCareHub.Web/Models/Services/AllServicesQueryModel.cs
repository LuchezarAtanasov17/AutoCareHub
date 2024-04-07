using AutoCareHub.Services.Services;

namespace AutoCareHub.Web.Models.Services
{
    /// <summary>
    /// Represents the all services query model.
    /// </summary>
    public class AllServicesQueryModel
    {
        /// <summary>
        /// Gets or sets the main category.
        /// </summary>
        public string? MainCategory { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the main categories.
        /// </summary>
        public List<string> MainCategories { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        public List<string> Cities { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the options for all or mine.
        /// </summary>
        public AllOrMineOption AllOrMineOption { get; set; }

        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        public List<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();
    }
}
