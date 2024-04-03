using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.ServiceRequests
{
    public static class Conversion
    {
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
