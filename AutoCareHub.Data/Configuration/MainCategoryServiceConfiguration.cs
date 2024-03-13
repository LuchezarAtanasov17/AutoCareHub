using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    public class MainCategoryServiceConfiguration : IEntityTypeConfiguration<MainCategoryService>
    {
        public void Configure(EntityTypeBuilder<MainCategoryService> builder)
        {
            builder.HasData(SeedMainCategoryServices());
        }
        private static List<MainCategoryService> SeedMainCategoryServices()
        {
            var mainCategoryServices = new List<MainCategoryService>()
            {
                new ()
                {
                    Id = Guid.Parse("1b04cddc-8fa9-4f11-b6b2-6276eb8cf094"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    ServiceId = Guid.Parse("dc4ee450-7e0d-4d13-b93f-474487d355d0")
                },
                new ()
                {
                    Id = Guid.Parse("29b077dd-c570-42a7-ba9b-fee2832aa7bd"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    ServiceId = Guid.Parse("ba0914fa-d680-4f2d-97b4-b6197e7a3902")
                },
                new ()
                {
                    Id = Guid.Parse("804aff14-701a-4908-8b7f-8a23d66a18dd"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    ServiceId = Guid.Parse("49450e6e-3fea-483c-9df8-ea6f9c91c6f8")
                },
                new ()
                {
                    Id = Guid.Parse("1d836613-8598-46b9-b94b-02764d26bb66"),
                    MainCategoryId = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    ServiceId = Guid.Parse("31059a53-4346-4efb-a1e2-b404c16b7fb5")
                },
            };

            return mainCategoryServices;
        }
    }
}
