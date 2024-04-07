using AutoCareHub.Services.Comments;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Comments
{
    /// <summary>
    /// Represents a conversion class for converting comment models.
    /// </summary>
    public class Conversion
    {
        #region Request To Entity

        /// <summary>
        /// Converts create comment request to entity model.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the entity comment</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ENTITIES.Comment ConvertComment(CreateCommentRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.Comment()
            {
                ServiceId = source.ServiceId,
                UserId = source.UserId,
                Value = source.Value,
                PublishedOn = DateTime.UtcNow,
            };

            return target;
        }

        #endregion
    }
}
