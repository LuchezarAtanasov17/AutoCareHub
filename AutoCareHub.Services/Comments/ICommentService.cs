using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Comments
{
    public interface ICommentService
    {
        Task<Comment> GetCommentAsync(Guid id);

        Task CreateCommentAsync(CreateCommentRequest request);

        Task DeleteCommentAsync(Guid id);
    }
}
