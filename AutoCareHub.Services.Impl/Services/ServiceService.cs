using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Exceptions;
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

        public async Task<List<ENTITIES.Service>> ListServicesAsync(Guid? userId = null,
            string? category = null,
            string? city = null,
            AllOrMineOption? allOrMineOption = null)
        {
            try
            {
                var services = await _context.Services
                    .Include(x => x.User)
                    .Include(x => x.Appointments)
                    .Include(x => x.Comments)
                    .Include(x => x.MainCategoryServices)
                    .ToListAsync();

                foreach (var service in services)
                {
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving services.", ex);
            }
        }

        public async Task<ENTITIES.Service> GetServiceAsync(Guid id)
        {
            try
            {
                var service = await _context.Services
                    .Include(x => x.User)
                    .Include(x => x.Appointments)
                    .Include(x => x.Comments)
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving a service with specified ID.", ex);
            }
        }

        public async Task CreateServiceAsync(CreateServiceRequest request)
        {
            try
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

                await _context.Services.AddAsync(entityService);
                await _context.SaveChangesAsync();

                if (request.Images != null)
                {
                    foreach (var imageInfo in request.Images)
                    {
                        var image = await _imageService.UploadImage(imageInfo, "images", entityService);
                    }
                    await _context.SaveChangesAsync();
                }

                ServiceRequest registerRequest = new ServiceRequest()
                {
                    Id = Guid.NewGuid(),
                    ServiceId = entityService.Id,
                    CreatedOn = DateTime.UtcNow,
                };

                await _context.ServiceRequests.AddAsync(registerRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while creating a service.", ex);
            }
        }

        public async Task UpdateServiceAsync(Guid id, UpdateServiceRequest request)
        {
            try
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
                service.OpenTime = TimeOnly.Parse(request.OpenTime);
                service.CloseTime = TimeOnly.Parse(request.CloseTime);
                service.City = request.City;
                service.Address = request.Address;
                service.Description = request.Description;

                var mainCategoryServices = _context.MainCategoryServices
                    .Where(x => x.ServiceId == service.Id);
                _context.MainCategoryServices.RemoveRange(mainCategoryServices);

                foreach (var mainCategory in request.SelectMainCategory.Where(x => x.IsSelected == true))
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while updating a service with specified ID.", ex);
            }
        }

        public async Task DeleteServiceAsync(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while deleting a service with specified ID.", ex);
            }
        }
    }
}
