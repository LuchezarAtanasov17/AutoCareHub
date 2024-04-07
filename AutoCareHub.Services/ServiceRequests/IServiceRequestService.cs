using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.CreateServiceRequests
{
    /// <summary>
    /// Provides access to service requests.
    /// </summary>
    public interface IServiceRequestService
    {
        /// <summary>
        /// Lists not approved.
        /// </summary>
        /// <returns>a collection of service requests</returns>
        Task<List<ServiceRequest>> ListNotApproved();

        /// <summary>
        /// Declines a request.
        /// </summary>
        /// <param name="id">the service request ID</param>
        Task Decline(Guid id);

        /// <summary>
        /// Approves a request.
        /// </summary>
        /// <param name="id">the service request ID</param>
        Task Approve(Guid id);
    }
}
