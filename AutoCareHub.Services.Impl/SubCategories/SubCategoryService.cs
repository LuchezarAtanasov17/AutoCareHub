using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.SubCategories;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AutoCareHubDbContext _context;

        public SubCategoryService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<SubCategory>> ListSubCategoriesAsync(Guid? mainCategoryId = null)
        {
            var subCategories = await _context.SubCategories.ToListAsync();

            if (mainCategoryId != null)
            {
                subCategories = subCategories.Where(x => x.MainCategoryId == mainCategoryId).ToList();
            }

            return subCategories;
        }

        public async Task<SubCategory> GetSubCategoryAsync(Guid id)
        {
            var subCategory = await _context.SubCategories.FirstOrDefaultAsync(x => x.Id == id);

            if (subCategory == null)
            {
                throw new ObjectNotFoundException(nameof(subCategory));
            }

            return subCategory;
        }

        public async Task CreateSubCategoryAsync(CreateSubCategoryRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubCategoryAsync(Guid id)
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
    }
}
