using AutoCareHub.Services.Services;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Impl.Services
{
    internal class Conversion
    {
        #region Request To Entity

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
            };

            return target;
        }

        #endregion
    }
}
