using AutoCareHub.Data.Models;

namespace AutoCareHub.Web.Models.ServiceRequests
{
    public class ServiceRequestViewModel
    {
        public Guid Id { get; set; }

        public Guid ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string OwnerName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
