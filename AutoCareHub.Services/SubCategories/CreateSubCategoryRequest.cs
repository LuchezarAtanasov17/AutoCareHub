using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.SubCategories
{
    public class CreateSubCategoryRequest
    {
        [Required]
        public Guid MainCategoryId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
