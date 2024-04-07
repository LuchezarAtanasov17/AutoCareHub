using AutoCareHub.Services.Services;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Services
{
    /// <summary>
    /// Represents a conversion class for converting service models.
    /// </summary>
    public class Conversion
    {
        #region Request To Entity

        /// <summary>
        /// Converts create service request to entity service.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the entity service</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ENTITIES.Service ConvertService(CreateServiceRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ENTITIES.Service()
            {
                Id = Guid.NewGuid(),
                UserId = source.UserId,
                Name = source.Name,
                OpenTime = TimeOnly.Parse(source.OpenTime),
                CloseTime = TimeOnly.Parse(source.CloseTime),
                City = source.City,
                Address = source.Address,
                Description = source.Description,
                IsApproved = false,
            };

            return target;
        }

        #endregion
    }
}
