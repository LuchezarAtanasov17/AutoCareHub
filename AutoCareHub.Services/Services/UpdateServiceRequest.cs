using AutoCareHub.Services.MainCategories;
using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.Services
{
    public class UpdateServiceRequest
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [StringLength(300)]
        public string? Description { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        public string Address { get; set; }

        [Required]
        public string OpenTime { get; set; }

        [Required]
        public string CloseTime { get; set; }

        public List<SelectMainCategory> SelectMainCategory { get; set; }
    }
}
