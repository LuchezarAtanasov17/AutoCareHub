namespace AutoCareHub.Web.Models.SubCategories
{
    public class SubCategoryViewModel
    {
        public Guid Id { get; set; }

        public Guid MainCategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string MainCategoryName { get; set; }
    }
}
