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
                UserId = source.UserId,
                Name = source.Name,
                OpenTime = source.OpenTime,
                CloseTime = source.CloseTime,
                Location = source.Location,
                Description = source.Description,
                ImageUrl = source.ImageUrl,
            };

            return target;
        }

        #endregion
    }
}
