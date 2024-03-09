﻿using AutoCareHub.Services.Services;
using AutoCareHub.Web.Model.Services;
using Microsoft.EntityFrameworkCore;
using AutoCareHub.Data;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Services
{
    public class ServiceService : IServiceService
    {
        private readonly AutoCareHubDbContext _context;

        public ServiceService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ENTITIES.Service>> ListServicesAsync(Guid? userId = null)
        {
            var services = await _context.Services
                .Include(x=>x.User)
                .Include(x=>x.Appointments)
                .Include(x=>x.Comments)
                .Include(x=>x.Ratings)
                .Include(x => x.MainCategoryServices)
                .ToListAsync();

            if (userId != null)
            {
                services = services
                    .Where(x => x.UserId == userId)
                    .ToList();
            }

            return services;
        }

        public async Task<ENTITIES.Service> GetServiceAsync(Guid id)
        {
            var service = await _context.Services
                .Include(x => x.User)
                .Include(x => x.Appointments)
                .Include(x => x.Comments)
                .Include(x => x.Ratings)
                .Include(x=>x.MainCategoryServices)
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