using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Comments
{
    public interface ICommentService
    {
        Task<List<Comment>> ListCommentsAsync(Guid? serviceId = null, Guid? userId = null);

        Task CreateCommentAsync(CreateCommentRequest request);

        Task DeleteCommentAsync(Guid id);
    }
}
