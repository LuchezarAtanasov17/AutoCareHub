using AutoCareHub.Services.Comments;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Comments
{
    internal class Conversion
    {
        #region Request To Entity
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
