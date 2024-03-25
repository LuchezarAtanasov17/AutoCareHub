using AutoCareHub.Services.MainCategories;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Services
{
    public class CreateServiceRequest
    {
        public Guid UserId { get; set; }

        public List<Guid> MainCategoryIds { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string City { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        public TimeOnly OpenTime { get; set; }

        [Required]
        public TimeOnly CloseTime { get; set; }

        public string ImageUrl { get; set; }

        public List<SelectMainCategory> MainCategories { get; set; }
    }
}
