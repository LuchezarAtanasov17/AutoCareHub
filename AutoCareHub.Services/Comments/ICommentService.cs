using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Comments
{
    /// <summary>
    /// Provides access to comments.
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// Gets a comment with specified ID.
        /// </summary>
        /// <param name="id">comment ID</param>
        /// <returns>a comment</returns>
        Task<Comment> GetCommentAsync(Guid id);

        /// <summary>
        /// Creates a comment.
        /// </summary>
        /// <param name="request">the request for creating a comment</param>
        Task CreateCommentAsync(CreateCommentRequest request);

        /// <summary>
        /// Deletes a specified comment.
        /// </summary>
        /// <param name="id">comment ID</param>
        Task DeleteCommentAsync(Guid id);
    }
}
