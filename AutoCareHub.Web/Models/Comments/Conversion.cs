using ENTITIES = AutoCareHub.Data.Models;
using WEB_USERS = AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Comments
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public class Conversion
    {
        /// <summary>
        /// Converts a entity comment to web comment.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web comment</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CommentViewModel ConvertComment(ENTITIES.Comment source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new CommentViewModel()
            {
                Id = source.Id,
                UserId = source.UserId,
                ServiceId = source.ServiceId,
                Value = source.Value,
                PublishedOn = source.PublishedOn,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
            };

            return target;
        }
    }
}
