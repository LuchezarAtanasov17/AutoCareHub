using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.CreateServiceRequests
{
    public interface IServiceRequestService
    {
        Task<List<ServiceRequest>> ListNotApproved();

        Task Decline(Guid id);

        Task Approve(Guid id);
    }
}
