using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(SeedRoles());
        }

        private static List<Role> SeedRoles()
        {
            var roles = new List<Role>()
            {
                new()
                {
                    Id = Guid.Parse("7c35c18b-3177-4ad1-8be7-141693a7272f"),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR".ToUpper(),
                    ConcurrencyStamp = "68be544a-11c3-493d-b40f-d6fa9b362c52"
                },
                new()
                {
                    Id = Guid.Parse("b61a261f-5220-4176-9d49-ff18ecbd5b18"),
                    Name = "User",
                    NormalizedName = "User".ToUpper(),
                    ConcurrencyStamp = "3a197fb9-6842-4b1a-ada3-89c75a45eaba"
                }
            };

            return roles;
        }
    }
}
