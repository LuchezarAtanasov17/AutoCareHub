using AutoCareHub.Data;
using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Exceptions;
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

        public async Task<ENTITIES.Comment> GetCommentAsync(Guid id)
        {
            try
            {
                var comment = await _context.Comments
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (comment == null)
                {
                    throw new ObjectNotFoundException(nameof(comment));
                }

                return comment;
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving a comment.", ex);
            }
        }

        public async Task CreateCommentAsync(CreateCommentRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                ENTITIES.Comment entityComment = Conversion.ConvertComment(request);

                await _context.Comments.AddAsync(entityComment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while creating a comment.", ex);
            }
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while deleting a comment with specified ID.", ex);
            }
        }
    }
}
