using AutoCareHub.Data;
using AutoCareHub.Services.Image;
using AutoCareHub.Services.Services;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AutoCareHubDbContext _context;
        private readonly IImageService _imageService;

        public ServiceService(AutoCareHubDbContext context, IImageService imageService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _imageService = imageService;
        }

        public async Task<List<ENTITIES.Service>> ListServicesAsync(Guid? userId = null, string? category = null, string? city = null, AllOrMineOption? allOrMineOption = null)
        {
            var services = await _context.Services
                .Include(x => x.User)
                .Include(x => x.Appointments)
                .Include(x => x.Comments)
                .Include(x => x.Ratings)
                .Include(x => x.MainCategoryServices)
                .ToListAsync();

            foreach (var service in services)
            {
                foreach (var mainCategoryService in service.MainCategoryServices)
                {
                    mainCategoryService.MainCategory = await _context.MainCategoryServices
                        .Select(x => x.MainCategory)
                        .FirstOrDefaultAsync(x => x.Id == mainCategoryService!.MainCategoryId) ?? throw new ArgumentNullException();

                    mainCategoryService.MainCategory.SubCategories = await _context.SubCategories.ToListAsync();
                }

                foreach (var comment in service.Comments)
                {
                    comment.User = await _context.Users.FirstAsync(x => x.Id == comment.UserId);
                }
            }

            if (category != null)
            {
                services = services
                    .Where(x => x.MainCategoryServices
                        .Select(x => x.MainCategory.Name)
                        .Contains(category))
                    .ToList();
            }
            if (city != null)
            {
                services = services
                    .Where(x => x.City == city)
                    .ToList();
            }

            services = allOrMineOption switch
            {
                AllOrMineOption.Mine => services.Where(x => x.UserId == userId).ToList(),
                _ => services.Where(x => x.UserId != userId).ToList()
            };

            return services;
        }

        public async Task<ENTITIES.Service> GetServiceAsync(Guid id)
        {
            var service = await _context.Services
                .Include(x => x.User)
                .Include(x => x.Appointments)
                .Include(x => x.Comments)
                .Include(x => x.Ratings)
                .Include(x => x.MainCategoryServices)
                .FirstOrDefaultAsync(x => x.Id == id);

            foreach (var mainCategoryService in service.MainCategoryServices)
            {
                mainCategoryService.MainCategory = await _context.MainCategoryServices
                    .Select(x => x.MainCategory)
                    .FirstOrDefaultAsync(x => x.Id == mainCategoryService!.MainCategoryId) ?? throw new ArgumentNullException();

                mainCategoryService.MainCategory.SubCategories = await _context.SubCategories
                    .Where(x => x.MainCategoryId == mainCategoryService.MainCategoryId)
                    .ToListAsync();
            }
            foreach (var comment in service.Comments)
            {
                comment.User = await _context.Users.FirstAsync(x => x.Id == comment.UserId);
            }

            if (service == null)
            {
                throw new ObjectNotFoundException(nameof(service));
            }

            return service;
        }

        public async Task CreateServiceAsync(CreateServiceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entityService = Conversion.ConvertService(request);

            foreach (var mainCategoryId in request.MainCategoryIds)
            {
                var mainCategoryService = new ENTITIES.MainCategoryService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = entityService.Id,
                    MainCategoryId = mainCategoryId,
                };

                await _context.MainCategoryServices.AddAsync(mainCategoryService);
            }

            await _context.AddAsync(entityService);
            await _context.SaveChangesAsync();

            if (request.Images != null)
            {
                foreach (var imageInfo in request.Images)
                {
                    var image = await _imageService.UploadImage(imageInfo, "images", entityService);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateServiceAsync(Guid id, UpdateServiceRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var service = await _context.Services
               .FirstOrDefaultAsync(x => x.Id == id);

            if (service is null)
            {
                throw new ObjectNotFoundException($"Could not find service with ID {id}.");
            }

            service.Name = request.Name;
            service.OpenTime = request.OpenTime;
            service.CloseTime = request.CloseTime;
            service.City = request.City;
            service.Address = request.Address;
            service.Description = request.Description;

            var mainCategoryServices = _context.MainCategoryServices
                .Where(x => x.ServiceId == service.Id);
            _context.MainCategoryServices.RemoveRange(mainCategoryServices);

            foreach (var mainCategory in request.SelectMainCategory)
            {
                var mainCategoryService = new ENTITIES.MainCategoryService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = service.Id,
                    MainCategoryId = mainCategory.Id,
                };

                await _context.MainCategoryServices.AddAsync(mainCategoryService);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(Guid id)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(x => x.Id == id);

            if (service is null)
            {
                throw new ObjectNotFoundException(nameof(service));
            }

            _context.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}
