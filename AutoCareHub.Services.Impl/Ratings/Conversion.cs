using AutoCareHub.Services.Ratings;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Ratings
{
    internal class Conversion
    {
        #region Request To Entity

        public static ENTITIES.Rating ConvertRating(UpdateRatingRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.Rating()
            {
                ServiceId = source.ServiceId,
                UserId = source.UserId,
                Value = source.Value,
            };

            return target;
        }

        #endregion
    }
}
