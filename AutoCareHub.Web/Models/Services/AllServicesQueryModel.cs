using AutoCareHub.Services.Services;

namespace AutoCareHub.Web.Models.Services
{
    public class AllServicesQueryModel
    {
        public string? MainCategory { get; set; }

        public string? City { get; set; }

        public List<string> MainCategories { get; set; } = new List<string>();

        public List<string> Cities { get; set; } = new List<string>();

        public AllOrMineOption AllOrMineOption { get; set; }

        public List<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();
    }
}
