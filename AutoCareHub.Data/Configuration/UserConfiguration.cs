using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(SeedUsers());
        }

        private static List<User> SeedUsers()
        {
            var users = new List<User>()
            {
                new()
                {
                    Id = Guid.Parse("1456c79b-7080-4586-8467-900a3cb033fe"),
                    UserName = "Administrator",
                    NormalizedUserName = "Administrator".ToUpper(),
                    Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com".ToUpper(),
                    FirstName = "Luchezar",
                    LastName = "Atanasov",
                },
                new()
                {
                    Id = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                    UserName = "Meetyou",
                    NormalizedUserName = "Meetyou".ToUpper(),
                    Email = "dimitar@mail.com",
                    NormalizedEmail = "dimitar@mail.com".ToUpper(),
                    FirstName = "Dimitar",
                    LastName = "Dimitrov"
                },
                new()
                {
                    Id = Guid.Parse("c895a6a4-113d-4669-aa7a-5fecfe3b504c"),
                    UserName = "MoniBonboni",
                    NormalizedUserName = "MoniBonboni".ToUpper(),
                    Email = "simonipal@mail.com",
                    NormalizedEmail = "simonipal@mail.com".ToUpper(),
                    FirstName = "Dimitar",
                    LastName = "Dimitrov"
                },
            };

            return users;
        }
    }
}
