﻿using AutoCareHub.Data;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.MainCategories;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.MainCategories
{
    public class MainCategoryService : IMainCategoryService
    {
        private readonly AutoCareHubDbContext _context;

        public MainCategoryService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ENTITIES.MainCategory>> ListMainCategoriesAsync(Guid? serviceId = null)
        {
            try
            {
                var mainCategories = await _context.MainCategories
                    .Include(x => x.Appointments)
                    .Include(x => x.MainCategoryServices)
                    .ToListAsync();

                foreach (var mainCategory in mainCategories)
                {
                    mainCategory.SubCategories = await _context.SubCategories
                        .Where(x => x.MainCategoryId == mainCategory.Id)
                        .ToListAsync();
                }

                if (serviceId != null)
                {
                    mainCategories = await _context.MainCategoryServices
                        .Where(x => x.ServiceId == serviceId)
                        .Select(x => x.MainCategory)
                        .ToListAsync();
                }

                return mainCategories;
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while retrieving main categories.");
            }
        }

        public async Task CreateMainCategoryAsync(CreateMainCategoryRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var entityMainCategory = Conversion.ConvertMainCategory(request);

                await _context.MainCategories.AddAsync(entityMainCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while creating a main category.");
            }
        }

        public async Task DeleteMainCategoryAsync(Guid id)
        {
            try
            {
                var mainCategory = await _context.MainCategories
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (mainCategory == null)
                {
                    throw new ObjectNotFoundException(nameof(mainCategory));
                }

                _context.Remove(mainCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while deleting a main category with specified ID.");
            }
        }
    }
}
