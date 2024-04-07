using AutoCareHub.Data;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Likes;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.Likes
{
    public class LikeService : ILikeService
    {
        private readonly AutoCareHubDbContext _context;

        public LikeService(AutoCareHubDbContext context)
        {
            this._context = context;
        }

        public async Task HandleLikeCommentAsync(Guid commentId, Guid userId)
        {
            try
            {
                var model = await _context.Users.Include(x => x.Likes).FirstOrDefaultAsync(x => x.Id == userId);

                if (model != null && !model.Likes.Select(x => x.CommentId).Contains(commentId))
                {
                    var like = new Data.Models.Like()
                    {
                        Id = Guid.NewGuid(),
                        CommentId = commentId,
                        UserId = userId
                    };

                    await _context.Likes.AddAsync(like);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var like = await _context.Likes.FirstOrDefaultAsync(x => x.CommentId == commentId && x.UserId == userId);

                    if (like == null)
                    {
                        throw new ArgumentNullException(nameof(like));
                    }

                    _context.Likes.Remove(like);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while liking comment.", ex);
            }
        }
    }
}
