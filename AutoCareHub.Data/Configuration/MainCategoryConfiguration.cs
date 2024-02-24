using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    internal class MainCategoryConfiguration : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasData(SeedMainCategories());
        }

        private static List<MainCategory> SeedMainCategories()
        {
            var mainCategories = new List<MainCategory>()
            {
                new MainCategory()
                {
                    Id = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Car repair",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Car maintenance",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Body work",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Tuning and performance",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire services",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Electrical services",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Inspections and diagnostics",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    Name = "Exterior washing",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("fe659df3-55ef-4c4b-b163-3a40f2c23397"),
                    Name = "Interior cleaning",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("b17b4f22-1199-4220-b651-e3e6b2927a0a"),
                    Name = "Detailing services",
                },
                new MainCategory()
                {
                    Id = Guid.Parse("f2c8d10f-f034-420f-a08f-c3d964689b72"),
                    Name = "Premium packages",
                },
            };

            return mainCategories;
        }
    }
}
