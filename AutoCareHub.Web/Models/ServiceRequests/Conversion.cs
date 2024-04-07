using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.ServiceRequests
{
    /// <summary>
    /// Represents a conversion class for converting web models.
    /// </summary>
    public static class Conversion
    {
        /// <summary>
        /// Converts a entity service request to web service request.
        /// </summary>
        /// <param name="source">the source</param>
        /// <returns>the web service request</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ServiceRequestViewModel ConvertServiceRequest(ENTITIES.ServiceRequest source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var target = new ServiceRequestViewModel()
            {
                Id = source.Id,
                ServiceId = source.ServiceId,
                CreatedOn = source.CreatedOn,
                ServiceName = source.Service.Name,
                OwnerName = source.Service.User.FirstName + " " + source.Service.User.LastName
            };

            return target;
        }
    }
}
