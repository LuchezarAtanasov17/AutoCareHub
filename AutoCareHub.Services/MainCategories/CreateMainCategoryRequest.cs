using System.ComponentModel.DataAnnotations;

namespace AutoCareHub.Services.MainCategories
{
    public class CreateMainCategoryRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
