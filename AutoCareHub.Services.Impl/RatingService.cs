﻿using AutoCareHub.Data;
using AutoCareHub.Services.Ratings;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl
{
    public class RatingService : IRatingService
    {
        private readonly AutoCareHubDbContext _context;

        public RatingService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task UpdateServiceRatingAsync(UpdateRatingRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entities = await _context.Ratings
                .Where(x => x.UserId == request.UserId && x.ServiceId == request.ServiceId)
                .ToListAsync();

            _context.Ratings.RemoveRange(entities);

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}