using AutoCareHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoCareHub.Data.Configuration
{
    internal class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(SeedServices());
        }

        private static List<Service> SeedServices()
        {
            var services = new List<Service>()
            {
                new()
                {
                    Id = Guid.Parse("dc4ee450-7e0d-4d13-b93f-474487d355d0"),
                    UserId = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                    Name = "ServiceSelect",
                    Description ="Welcome to ServiceSelect — your one-stop destination for hassle-free car service." +
                                " Browse, book, and relax as we connect you with trusted mechanics for all your automotive needs." +
                                " Experience convenience at your fingertips. Get started today!",
                    OpenTime = TimeOnly.Parse("9:00:00"),
                    CloseTime = TimeOnly.Parse("18:00:00"),
                    Location = "Gabrovo ulitsa \"Orlovska\" 24",
                    ImageUrl = "https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708796935/a4jdxgbvivhpsctgjtku.png"
                },
                new()
                {
                    Id = Guid.Parse("ba0914fa-d680-4f2d-97b4-b6197e7a3902"),
                    UserId = Guid.Parse("62448744-4356-44dc-a005-0bfb6ba9e8b2"),
                    Name = "CarProCare",
                    Description ="Experience the ultimate in automotive convenience with DriveEase." +
                                " Say goodbye to long wait times and tedious phone calls—we've streamlined the process for you." +
                                " From routine maintenance to emergency repairs, our platform connects you with skilled professionals ready to serve." +
                                " Relax and let DriveEase take the wheel on your car care journey.",
                    OpenTime = TimeOnly.Parse("9:00:00"),
                    CloseTime = TimeOnly.Parse("18:00:00"),
                    Location = "Sofia, ulitsa \"Hristo Belchev\" 10",
                    ImageUrl = "https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708797988/nonue5t35kqw6tgsemng.jpg"
                },
                new()
                {
                    Id = Guid.Parse("49450e6e-3fea-483c-9df8-ea6f9c91c6f8"),
                    UserId = Guid.Parse("c895a6a4-113d-4669-aa7a-5fecfe3b504c"),
                    Name = "CarServiceCentral",
                    Description ="Welcome to AutoCare Connect—your one-stop destination for hassle-free car service." +
                                " Browse, book, and relax as we connect you with trusted mechanics for all your automotive needs." +
                                " Experience convenience at your fingertips. Get started today!",
                    OpenTime = TimeOnly.Parse("8:00:00"),
                    CloseTime = TimeOnly.Parse("18:00:00"),
                    Location = "Varna, ulitsa \"San Stefano\" 14",
                    ImageUrl = "https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708798216/zvk1f91ntnsvofjmu5hk.jpg",
                },
                new()
                {
                    Id = Guid.Parse("31059a53-4346-4efb-a1e2-b404c16b7fb5"),
                    UserId = Guid.Parse("c895a6a4-113d-4669-aa7a-5fecfe3b504c"),
                    Name = "AutoPureWash",
                    Description = "Welcome to AutoPureWash, where your vehicle's shine is our priority. " +
                                "Treat your car to a rejuvenating experience with our expert team and state-of-the-art equipment. " +
                                "From exterior washes to meticulous detailing, we offer a range of services tailored to suit your needs. " +
                                "Experience the ultimate in cleanliness and convenience at AutoPureWash—where every wash leaves your car sparkling like new.",
                    OpenTime = TimeOnly.Parse("8:00:00"),
                    CloseTime = TimeOnly.Parse("17:00:00"),
                    Location = "Plovdiv, ulitsa \"Ivan Vazov\" 17",
                    ImageUrl = "https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708797989/jhqtxfrhy22egoizyxia.jpg"
                }
            };

            return services;
        }
    }
}
