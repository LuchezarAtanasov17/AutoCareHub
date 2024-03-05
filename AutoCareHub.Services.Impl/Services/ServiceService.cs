using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Model.Services;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AutoCareHubDbContext _context;

        public ServiceService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Service>> ListServicesAsync(Guid? userId = null)
        {
            var services = await _context.Services.ToListAsync();

            if (userId != null)
            {
                services = services
                    .Where(x => x.UserId == userId)
                    .ToList();
            }

            return services;
        }

        public async Task<Service> GetServiceAsync(Guid id)
        {
            var service = await _context.Services
                .FirstOrDefaultAsync(x => x.Id == id);

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

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
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
            service.Location = request.Location;
            service.Description = request.Description;

            var mainCategoryServices = _context.MainCategoryServices.Where(x => x.ServiceId == service.Id);
            _context.MainCategoryServices.RemoveRange(mainCategoryServices);

            foreach (var category in request.MainCategories)
            {
                var categoryService = new MainCategoryService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = service.Id,
                    MainCategoryId = category.Id,
                };

                await _context.MainCategoryServices.AddAsync(categoryService);
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
