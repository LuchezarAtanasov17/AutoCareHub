using AutoCareHub.Data;
using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Image;
using AutoCareHub.Services.Impl;
using AutoCareHub.Services.Impl.Image;
using AutoCareHub.Services.Impl.Likes;
using AutoCareHub.Services.Impl.MainCategories;
using AutoCareHub.Services.Impl.Ratings;
using AutoCareHub.Services.Impl.Services;
using AutoCareHub.Services.Impl.SubCategories;
using AutoCareHub.Services.Impl.Users;
using AutoCareHub.Services.Likes;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Ratings;
using AutoCareHub.Services.Services;
using AutoCareHub.Services.SubCategories;
using AutoCareHub.Services.Users;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AutoCareHubDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ENTITIES.User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
    .AddRoles<ENTITIES.Role>()
    .AddEntityFrameworkStores<AutoCareHubDbContext>();
builder.Services.AddControllersWithViews();

ConfigureCloudinaryService(builder.Services, builder.Configuration);

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ILikeService, LikeService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://localhost:7256")
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "PUT")
                .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();
});

// Migrate database
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<AutoCareHubDbContext>();
    await dataContext.Database.MigrateAsync();
}

app.Run();

static void ConfigureCloudinaryService(IServiceCollection services, IConfiguration configuration)
{

    var cloudName = configuration.GetValue<string>("AccountSettings:CloudName");
    var apiKey = configuration.GetValue<string>("AccountSettings:ApiKey");
    var apiSecret = configuration.GetValue<string>("AccountSettings:ApiSecret");

    if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
    {
        throw new ArgumentException("Please specify your Cloudinary account Information");
    }

    services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
}
