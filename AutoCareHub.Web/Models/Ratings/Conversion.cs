using ENTITIES = AutoCareHub.Data.Models;
using WEB_USERS = AutoCareHub.Web.Models.Users;

namespace AutoCareHub.Web.Models.Ratings
{
    public class Conversion
    {
        public static RatingViewModel ConvertRating(ENTITIES.Rating source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new RatingViewModel()
            {
                UserId = source.UserId,
                ServiceId = source.ServiceId,
                Value = source.Value,
                User = WEB_USERS.Conversion.ConvertUser(source.User),
            };

            return target;
        }
    }
}
