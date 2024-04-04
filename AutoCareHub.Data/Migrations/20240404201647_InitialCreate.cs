using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCareHub.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    OpenTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CloseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainCategoryServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MainCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategoryServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCategoryServices_MainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainCategoryServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequests_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("7c35c18b-3177-4ad1-8be7-141693a7272f"), "68be544a-11c3-493d-b40f-d6fa9b362c52", "Administrator", "ADMINISTRATOR" },
                    { new Guid("b61a261f-5220-4176-9d49-ff18ecbd5b18"), "3a197fb9-6842-4b1a-ada3-89c75a45eaba", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1456c79b-7080-4586-8467-900a3cb033fe"), 0, "c49b6c53-6035-4e5a-8588-089192bcf5f8", "admin@gmail.com", false, "Luchezar", "Atanasov", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", null, "1234567891", false, null, false, "Administrator" },
                    { new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2"), 0, "ea9ba76d-1ea2-4595-b73d-f0c367899c71", "dimitar@mail.com", false, "Dimitar", "Dimitrov", false, null, "DIMITAR@MAIL.COM", "MEETYOU", null, "1234567899", false, null, false, "Meetyou" },
                    { new Guid("c895a6a4-113d-4669-aa7a-5fecfe3b504c"), 0, "da3fff58-3847-4d6f-b450-3efd80505039", "simonipal@mail.com", false, "Dimitar", "Dimitrov", false, null, "SIMONIPAL@MAIL.COM", "MONIBONBONI", null, "1234567890", false, null, false, "MoniBonboni" }
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Tuning and performance" },
                    { new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire services" },
                    { new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Electrical services" },
                    { new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Body work" },
                    { new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Car maintenance" },
                    { new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Car repair" },
                    { new Guid("b17b4f22-1199-4220-b651-e3e6b2927a0a"), "Detailing services" },
                    { new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Inspections and diagnostics" },
                    { new Guid("f2c8d10f-f034-420f-a08f-c3d964689b72"), "Premium packages" },
                    { new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), "Exterior washing" },
                    { new Guid("fe659df3-55ef-4c4b-b163-3a40f2c23397"), "Interior cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Address", "City", "CloseTime", "Description", "ImageUrls", "IsApproved", "Name", "OpenTime", "UserId" },
                values: new object[,]
                {
                    { new Guid("31059a53-4346-4efb-a1e2-b404c16b7fb5"), "ulitsa Ivan Vazov 17", "Plovdiv", new TimeSpan(0, 17, 0, 0, 0), "Welcome to AutoPureWash, where your vehicle's shine is our priority. Treat your car to a rejuvenating experience with our expert team and state-of-the-art equipment. From exterior washes to meticulous detailing, we offer a range of services tailored to suit your needs. Experience the ultimate in cleanliness and convenience at AutoPureWash—where every wash leaves your car sparkling like new.", "[\"https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708797989/jhqtxfrhy22egoizyxia.jpg\"]", true, "AutoPureWash", new TimeSpan(0, 8, 0, 0, 0), new Guid("c895a6a4-113d-4669-aa7a-5fecfe3b504c") },
                    { new Guid("49450e6e-3fea-483c-9df8-ea6f9c91c6f8"), "ulitsa San Stefano 14", "Varna", new TimeSpan(0, 18, 0, 0, 0), "Welcome to AutoCare Connect—your one-stop destination for hassle-free car service. Browse, book, and relax as we connect you with trusted mechanics for all your automotive needs. Experience convenience at your fingertips. Get started today!", "[\"https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708798216/zvk1f91ntnsvofjmu5hk.jpg\"]", true, "CarServiceCentral", new TimeSpan(0, 8, 0, 0, 0), new Guid("c895a6a4-113d-4669-aa7a-5fecfe3b504c") },
                    { new Guid("ba0914fa-d680-4f2d-97b4-b6197e7a3902"), "ulitsa Hristo Belchev 10", "Sofia", new TimeSpan(0, 18, 0, 0, 0), "Experience the ultimate in automotive convenience with DriveEase. Say goodbye to long wait times and tedious phone calls—we've streamlined the process for you. From routine maintenance to emergency repairs, our platform connects you with skilled professionals ready to serve. Relax and let DriveEase take the wheel on your car care journey.", "[\"https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708797988/nonue5t35kqw6tgsemng.jpg\"]", true, "CarProCare", new TimeSpan(0, 9, 0, 0, 0), new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2") },
                    { new Guid("dc4ee450-7e0d-4d13-b93f-474487d355d0"), "ulitsa Orlovska 24", "Gabrovo", new TimeSpan(0, 18, 0, 0, 0), "Welcome to ServiceSelect — your one-stop destination for hassle-free car service. Browse, book, and relax as we connect you with trusted mechanics for all your automotive needs. Experience convenience at your fingertips. Get started today!", "[\"https://res.cloudinary.com/ddbrt2xfu/image/upload/v1708796935/a4jdxgbvivhpsctgjtku.png\"]", true, "ServiceSelect", new TimeSpan(0, 9, 0, 0, 0), new Guid("62448744-4356-44dc-a005-0bfb6ba9e8b2") }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("00a801b4-c869-49a8-b7af-fe272f3c7a33"), new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Computer diagnostics" },
                    { new Guid("01baf66c-6c1a-4078-b663-a01b829594ca"), new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), "Foam cannon wash" },
                    { new Guid("03b580f6-af09-40cc-b68a-bdd9514b33cc"), new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), "Hand wash" },
                    { new Guid("098abbe9-b25d-4d4c-a3cd-ad968d4ddeb5"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Exhaust system repairs" },
                    { new Guid("0b5cbb43-a7e8-4c57-9079-144743e628bd"), new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Starter repair/replacement" },
                    { new Guid("0d3270e4-054f-44dc-8afe-018c4b08afdf"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Cooling system repairs" },
                    { new Guid("0fbe31c2-c3d7-4d85-9fb4-f0498fd49cb8"), new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire alignment" },
                    { new Guid("13c8a627-246a-4217-b435-7b7895b37572"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Engine repairs" },
                    { new Guid("1ac17698-13f1-45ec-a06a-bd79f2fc7ba5"), new Guid("fe659df3-55ef-4c4b-b163-3a40f2c23397"), "Upholstery cleaning (cloth and leather)" },
                    { new Guid("1ae92eca-75b8-4c67-80a6-e735ba5978e2"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Battery Checks and Replacements" },
                    { new Guid("20302865-c0f0-45ec-aa1c-051d3078e76a"), new Guid("b17b4f22-1199-4220-b651-e3e6b2927a0a"), "Waxing" },
                    { new Guid("2142b12d-b35f-43d3-9eda-2add0185440e"), new Guid("f2c8d10f-f034-420f-a08f-c3d964689b72"), "Paint protection film installation" },
                    { new Guid("2fd08be9-afe6-4d07-96fa-6200ba603412"), new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Brake system inspections" },
                    { new Guid("2ffbd815-9cd9-4705-b92e-2d399e92fb77"), new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Lighting System Repairs (headlights, taillights, etc.)" },
                    { new Guid("3d7fd174-c8bb-4736-a471-a068d5d9ed48"), new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Accessory installation" },
                    { new Guid("4282bf09-84d6-4959-a617-d5d77204783b"), new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Exhaust system upgrades" },
                    { new Guid("44cf2177-f416-4ac8-8a59-39789812f60f"), new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Engine tuning" },
                    { new Guid("5146d4d9-edb9-4245-a238-57262f5aee94"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Transmission repairs" },
                    { new Guid("5c1d3518-a1db-4227-9fc6-97f41a90431b"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Scratch repair" },
                    { new Guid("6d979ed1-2dc2-4aa3-b93e-63bfeaa236bc"), new Guid("b17b4f22-1199-4220-b651-e3e6b2927a0a"), "Polishing" },
                    { new Guid("6dd2ecf1-4247-4917-be81-fc7ce8e16b90"), new Guid("fe659df3-55ef-4c4b-b163-3a40f2c23397"), "Carpet cleaning" },
                    { new Guid("73da4868-555b-496c-b8e2-4188c0f59495"), new Guid("f2c8d10f-f034-420f-a08f-c3d964689b72"), "Ceramic coating application" },
                    { new Guid("78f24d6e-46fe-4319-9e8b-dd874eb869b6"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Paint touch-ups" },
                    { new Guid("798939fe-a6c9-44fc-948b-87b3294790c9"), new Guid("b17b4f22-1199-4220-b651-e3e6b2927a0a"), "Clay bar treatment" },
                    { new Guid("7a46bde2-59b1-4df5-a72d-ce74451aae1a"), new Guid("f2c8d10f-f034-420f-a08f-c3d964689b72"), "Executive detail (includes interior and exterior detailing)" },
                    { new Guid("7fba968c-06a0-48af-b0d6-219795431073"), new Guid("f2c8d10f-f034-420f-a08f-c3d964689b72"), "Deluxe wash (includes waxing and polishing)" },
                    { new Guid("81337b94-310e-489b-af1e-c7ec871d712d"), new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Emissions testing" },
                    { new Guid("81f4bc54-7760-41a8-b3a1-15686003be70"), new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), "Automated wash" },
                    { new Guid("83f88cea-8cfc-4e1a-ac1c-fb584b3d651b"), new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Pre-purchase inspections" },
                    { new Guid("898abea7-8b86-4535-8081-5d12adc717a3"), new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), "Pressure washing" },
                    { new Guid("908396e9-8005-4a01-a94b-3148f4db366e"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Oil change" },
                    { new Guid("93a962f5-7480-4dd4-8a16-0903cba27f7f"), new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Suspension upgrades" },
                    { new Guid("a5243a06-e81e-4a72-964d-e91884adf681"), new Guid("b17b4f22-1199-4220-b651-e3e6b2927a0a"), "Tire and rim cleaning" },
                    { new Guid("a5980160-9996-4674-af02-4d037bb40563"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Fluid Checks and Replacements" },
                    { new Guid("a6105b47-b165-47f4-91dd-573d0941cd47"), new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Aesthetic modifications (body kits, spoilers, etc.)" },
                    { new Guid("a86af07c-b7f1-49ad-a531-97d1d0f42378"), new Guid("d8ca8195-48f6-4041-ac87-8b919d651e67"), "Check engine light diagnostics" },
                    { new Guid("ab3564f7-d534-4cfb-ba38-316526022524"), new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire rotation" },
                    { new Guid("b1a4a80a-aadb-4ea3-9ab0-2e185b4401d9"), new Guid("fe659df3-55ef-4c4b-b163-3a40f2c23397"), "Dashboard and console cleaning" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "MainCategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("c3a5935f-0594-4787-8f34-e979a04c9c72"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Dent repair" },
                    { new Guid("c81fb26c-be24-4949-9131-e0da9bb2d2ca"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Brake repairs" },
                    { new Guid("d66b052f-20cf-4433-95d7-b679c29be81e"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), "Suspension repairs" },
                    { new Guid("da92ee8e-c57b-4edc-b723-e8a415b6c5b7"), new Guid("fe659df3-55ef-4c4b-b163-3a40f2c23397"), "Vacuuming" },
                    { new Guid("dff7ba0d-2d95-426e-8720-b1ac1a51c3f3"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Bumper repair/replacement" },
                    { new Guid("e2723369-65c2-4c3b-b065-eaaf5e7fbea0"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), "Rust repair" },
                    { new Guid("e394f5f3-43f2-4dc2-a7f8-e6b801275e53"), new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Battery replacement" },
                    { new Guid("e3e2e7e7-74f4-4c86-a42b-0c0eda97d017"), new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire replacement" },
                    { new Guid("e7569e41-86b7-434a-8f33-8f9dbe24da90"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Filter replacements" },
                    { new Guid("e96a5563-c720-4bab-8976-8cfda7fd09bf"), new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire balancing" },
                    { new Guid("eb8ea1f8-a631-413f-a74c-d6d305c5c972"), new Guid("3d804f6d-78f5-4796-ac7b-b0f741724164"), "Performance chip installation" },
                    { new Guid("f730d322-61a8-4b4d-aaa0-2feafcfc8e11"), new Guid("61790e6f-1cb7-48b9-a207-8868ef458c63"), "Wiring repairs" },
                    { new Guid("f7da57a9-e68e-4440-8234-894fc63f102a"), new Guid("5f20784f-c7c1-43bb-bb9e-594aad69649e"), "Tire Pressure Monitoring System (TPMS) Services" },
                    { new Guid("fb2dca30-5f4a-4159-ba71-6bc44428f915"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), "Belt and Hose Inspections/Replacements" }
                });

            migrationBuilder.InsertData(
                table: "MainCategoryServices",
                columns: new[] { "Id", "MainCategoryId", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("1b04cddc-8fa9-4f11-b6b2-6276eb8cf094"), new Guid("accfbc90-1486-44b8-9a97-caeecf550391"), new Guid("dc4ee450-7e0d-4d13-b93f-474487d355d0") },
                    { new Guid("1d836613-8598-46b9-b94b-02764d26bb66"), new Guid("f9cd2d78-221c-46ff-9a2f-8d22e3a3f2a3"), new Guid("31059a53-4346-4efb-a1e2-b404c16b7fb5") },
                    { new Guid("29b077dd-c570-42a7-ba9b-fee2832aa7bd"), new Guid("8317f4c5-3f8b-4020-bbcf-2adb5e30639b"), new Guid("ba0914fa-d680-4f2d-97b4-b6197e7a3902") },
                    { new Guid("804aff14-701a-4908-8b7f-8a23d66a18dd"), new Guid("6a62c3f8-aa54-4857-9599-fcbba31da47d"), new Guid("49450e6e-3fea-483c-9df8-ea6f9c91c6f8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_MainCategoryId",
                table: "Appointments",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ServiceId",
                table: "Appointments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ServiceId",
                table: "Comments",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCategoryServices_MainCategoryId",
                table: "MainCategoryServices",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCategoryServices_ServiceId",
                table: "MainCategoryServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequests_ServiceId",
                table: "ServiceRequests",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_UserId",
                table: "Services",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_MainCategoryId",
                table: "SubCategories",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "MainCategoryServices");

            migrationBuilder.DropTable(
                name: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "MainCategories");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
