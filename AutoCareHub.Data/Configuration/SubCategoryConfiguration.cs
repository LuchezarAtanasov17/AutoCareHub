using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData(SeedSubCategories());
        }

        private static List<SubCategory> SeedSubCategories()
        {
            var allSubCategories = new List<SubCategory>();

            #region Car repair
            var subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("13c8a627-246a-4217-b435-7b7895b37572"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Engine repairs",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("c81fb26c-be24-4949-9131-e0da9bb2d2ca"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Brake repairs",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("5146d4d9-edb9-4245-a238-57262f5aee94"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Transmission repairs",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("d66b052f-20cf-4433-95d7-b679c29be81e"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Suspension repairs",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("098abbe9-b25d-4d4c-a3cd-ad968d4ddeb5"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Exhaust system repairs",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("0d3270e4-054f-44dc-8afe-018c4b08afdf"),
                    MainCategoryId = Guid.Parse("accfbc90-1486-44b8-9a97-caeecf550391"),
                    Name = "Cooling system repairs",
                },
            };

            allSubCategories.AddRange(subCategories);
            #endregion

            #region Car maintenance
            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("908396e9-8005-4a01-a94b-3148f4db366e"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Oil change",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("e7569e41-86b7-434a-8f33-8f9dbe24da90"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Filter replacements",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("a5980160-9996-4674-af02-4d037bb40563"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Fluid Checks and Replacements",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("fb2dca30-5f4a-4159-ba71-6bc44428f915"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Belt and Hose Inspections/Replacements",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("1ae92eca-75b8-4c67-80a6-e735ba5978e2"),
                    MainCategoryId = Guid.Parse("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"),
                    Name = "Battery Checks and Replacements",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Body work
            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("c3a5935f-0594-4787-8f34-e979a04c9c72"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Dent repair",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("5c1d3518-a1db-4227-9fc6-97f41a90431b"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Scratch repair",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("78f24d6e-46fe-4319-9e8b-dd874eb869b6"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Paint touch-ups",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("dff7ba0d-2d95-426e-8720-b1ac1a51c3f3"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Bumper repair/replacement",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("e2723369-65c2-4c3b-b065-eaaf5e7fbea0"),
                    MainCategoryId = Guid.Parse("6a62c3f8-aa54-4857-9599-fcbba31da47d"),
                    Name = "Rust repair",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Tuning and performance
            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("44cf2177-f416-4ac8-8a59-39789812f60f"),
                    MainCategoryId = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Engine tuning",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("93a962f5-7480-4dd4-8a16-0903cba27f7f"),
                    MainCategoryId = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Suspension upgrades",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("4282bf09-84d6-4959-a617-d5d77204783b"),
                    MainCategoryId = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Exhaust system upgrades",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("eb8ea1f8-a631-413f-a74c-d6d305c5c972"),
                    MainCategoryId = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Performance chip installation",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("a6105b47-b165-47f4-91dd-573d0941cd47"),
                    MainCategoryId = Guid.Parse("3d804f6d-78f5-4796-ac7b-b0f741724164"),
                    Name = "Aesthetic modifications (body kits, spoilers, etc.)",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Tire services
            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("ab3564f7-d534-4cfb-ba38-316526022524"),
                    MainCategoryId = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire rotation",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("e96a5563-c720-4bab-8976-8cfda7fd09bf"),
                    MainCategoryId = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire balancing",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("0fbe31c2-c3d7-4d85-9fb4-f0498fd49cb8"),
                    MainCategoryId = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire alignment",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("e3e2e7e7-74f4-4c86-a42b-0c0eda97d017"),
                    MainCategoryId = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire replacement",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("f7da57a9-e68e-4440-8234-894fc63f102a"),
                    MainCategoryId = Guid.Parse("5f20784f-c7c1-43bb-bb9e-594aad69649e"),
                    Name = "Tire Pressure Monitoring System (TPMS) Services",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Electrical services

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("e394f5f3-43f2-4dc2-a7f8-e6b801275e53"),
                    MainCategoryId = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Battery replacement",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("0b5cbb43-a7e8-4c57-9079-144743e628bd"),
                    MainCategoryId = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Starter repair/replacement",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("f730d322-61a8-4b4d-aaa0-2feafcfc8e11"),
                    MainCategoryId = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Wiring repairs",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("3d7fd174-c8bb-4736-a471-a068d5d9ed48"),
                    MainCategoryId = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Accessory installation",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("2ffbd815-9cd9-4705-b92e-2d399e92fb77"),
                    MainCategoryId = Guid.Parse("61790e6f-1cb7-48b9-a207-8868ef458c63"),
                    Name = "Lighting System Repairs (headlights, taillights, etc.)",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Inspections and diagnostics

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("00a801b4-c869-49a8-b7af-fe272f3c7a33"),
                    MainCategoryId = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Computer diagnostics",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("81337b94-310e-489b-af1e-c7ec871d712d"),
                    MainCategoryId = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Emissions testing",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("a86af07c-b7f1-49ad-a531-97d1d0f42378"),
                    MainCategoryId = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Check engine light diagnostics",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("2fd08be9-afe6-4d07-96fa-6200ba603412"),
                    MainCategoryId = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Brake system inspections",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("83f88cea-8cfc-4e1a-ac1c-fb584b3d651b"),
                    MainCategoryId = Guid.Parse("d8ca8195-48f6-4041-ac87-8b919d651e67"),
                    Name = "Pre-purchase inspections",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Exterior washing

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("03b580f6-af09-40cc-b68a-bdd9514b33cc"),
                    MainCategoryId = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    Name = "Hand wash",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("81f4bc54-7760-41a8-b3a1-15686003be70"),
                    MainCategoryId = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    Name = "Automated wash",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("898abea7-8b86-4535-8081-5d12adc717a3"),
                    MainCategoryId = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    Name = "Pressure washing",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("01baf66c-6c1a-4078-b663-a01b829594ca"),
                    MainCategoryId = Guid.Parse("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"),
                    Name = "Foam cannon wash",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Interior cleaning

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("da92ee8e-c57b-4edc-b723-e8a415b6c5b7"),
                    MainCategoryId = Guid.Parse("fe659df3-55ef-4c4b-b163-3a40f2c23397"),
                    Name = "Vacuuming",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("b1a4a80a-aadb-4ea3-9ab0-2e185b4401d9"),
                    MainCategoryId = Guid.Parse("fe659df3-55ef-4c4b-b163-3a40f2c23397"),
                    Name = "Dashboard and console cleaning",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("1ac17698-13f1-45ec-a06a-bd79f2fc7ba5"),
                    MainCategoryId = Guid.Parse("fe659df3-55ef-4c4b-b163-3a40f2c23397"),
                    Name = "Upholstery cleaning (cloth and leather)",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("6dd2ecf1-4247-4917-be81-fc7ce8e16b90"),
                    MainCategoryId = Guid.Parse("fe659df3-55ef-4c4b-b163-3a40f2c23397"),
                    Name = "Carpet cleaning",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Detailing services

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("20302865-c0f0-45ec-aa1c-051d3078e76a"),
                    MainCategoryId = Guid.Parse("b17b4f22-1199-4220-b651-e3e6b2927a0a"),
                    Name = "Waxing",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("6d979ed1-2dc2-4aa3-b93e-63bfeaa236bc"),
                    MainCategoryId = Guid.Parse("b17b4f22-1199-4220-b651-e3e6b2927a0a"),
                    Name = "Polishing",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("798939fe-a6c9-44fc-948b-87b3294790c9"),
                    MainCategoryId = Guid.Parse("b17b4f22-1199-4220-b651-e3e6b2927a0a"),
                    Name = "Clay bar treatment",

                },
                new SubCategory()
                {
                    Id = Guid.Parse("a5243a06-e81e-4a72-964d-e91884adf681"),
                    MainCategoryId = Guid.Parse("b17b4f22-1199-4220-b651-e3e6b2927a0a"),
                    Name = "Tire and rim cleaning",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            #region Premium packages

            subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("7fba968c-06a0-48af-b0d6-219795431073"),
                    MainCategoryId = Guid.Parse("f2c8d10f-f034-420f-a08f-c3d964689b72"),
                    Name = "Deluxe wash (includes waxing and polishing)",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("7a46bde2-59b1-4df5-a72d-ce74451aae1a"),
                    MainCategoryId = Guid.Parse("f2c8d10f-f034-420f-a08f-c3d964689b72"),
                    Name = "Executive detail (includes interior and exterior detailing)",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("73da4868-555b-496c-b8e2-4188c0f59495"),
                    MainCategoryId = Guid.Parse("f2c8d10f-f034-420f-a08f-c3d964689b72"),
                    Name = "Ceramic coating application",
                },
                new SubCategory()
                {
                    Id = Guid.Parse("2142b12d-b35f-43d3-9eda-2add0185440e"),
                    MainCategoryId = Guid.Parse("f2c8d10f-f034-420f-a08f-c3d964689b72"),
                    Name = "Paint protection film installation",
                },
            };

            allSubCategories.AddRange(subCategories);

            #endregion

            return allSubCategories;
        }
    }
}
