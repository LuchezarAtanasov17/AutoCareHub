using AutoCareHub.Data;
using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Impl.Comments;
using Microsoft.EntityFrameworkCore;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl
{
    public class CommentService : ICommentService
    {
        private readonly AutoCareHubDbContext _context;

        public CommentService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ENTITIES.Comment>> ListCommentsAsync(Guid? serviceId = null, Guid? userId = null)
        {
            var comments = await _context.Comments
                .Include(x => x.User)
                .Include(x => x.Service)
                .ToListAsync();

            if (serviceId != null)
            {
                comments = comments
                    .Where(x => x.ServiceId == serviceId)
                    .ToList();
            }
            if (userId != null)
            {
                comments = comments
                    .Where(x => x.UserId == userId)
                    .ToList();
            }

            return comments;
        }

        public async Task<ENTITIES.Comment> GetCommentAsync(Guid id)
        {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                throw new ObjectNotFoundException(nameof(comment));
            }

            return comment;
        }

        public async Task CreateCommentAsync(CreateCommentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            ENTITIES.Comment entityComment = Conversion.ConvertComment(request);

            await _context.AddAsync(entityComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                throw new ObjectNotFoundException(nameof(comment));
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}
