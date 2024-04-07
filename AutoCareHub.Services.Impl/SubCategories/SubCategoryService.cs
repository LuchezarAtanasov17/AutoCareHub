﻿using AutoCareHub.Data;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.SubCategories;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AutoCareHubDbContext _context;

        public SubCategoryService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ENTITIES.SubCategory>> ListSubCategoriesAsync(Guid? mainCategoryId = null)
        {
            try
            {
                var subCategories = await _context.SubCategories
                    .Include(x => x.MainCategory)
                    .ToListAsync();

                if (mainCategoryId != null)
                {
                    subCategories = subCategories
                        .Where(x => x.MainCategoryId == mainCategoryId)
                        .ToList();
                }

                return subCategories;
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving sub categories.", ex);
            }
        }

        public async Task CreateSubCategoryAsync(CreateSubCategoryRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var entitySubCategory = Conversion.ConvertSubCategory(request);

                await _context.SubCategories.AddAsync(entitySubCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while creating a sub category.", ex);
            }
        }

        public async Task DeleteSubCategoryAsync(Guid id)
        {
            try
            {
                var subCategory = await _context.SubCategories
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (subCategory == null)
                {
                    throw new ObjectNotFoundException(nameof(subCategory));
                }

                _context.Remove(subCategory);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while deleting a sub category with specified ID.", ex);
            }
        }

        public async Task<int> Count()
        {
            try
            {
                int count = await _context.SubCategories.CountAsync();

                return count;
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving the count of sub categories.", ex);
            }
        }
    }
}
