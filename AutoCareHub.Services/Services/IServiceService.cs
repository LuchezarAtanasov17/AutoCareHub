using AutoCareHub.Data.Models;

namespace AutoCareHub.Services.Services
{
    /// <summary>
    /// Provides access to services.
    /// </summary>
    public interface IServiceService
    {
        /// <summary>
        /// Lists services.
        /// </summary>
        /// <param name="userId">the user ID</param>
        /// <param name="category">the category</param>
        /// <param name="city">the city</param>
        /// <param name="allOrMineOption">the option for all or mine</param>
        /// <returns>a collection of services</returns>
        Task<List<Service>> ListServicesAsync(Guid? userId = null, string? category = null, string? city = null, AllOrMineOption? allOrMineOption = null);

        /// <summary>
        /// Gets a service with specified ID.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <returns>a service</returns>
        Task<Service> GetServiceAsync(Guid id);

        /// <summary>
        /// Creates a service.
        /// </summary>
        /// <param name="request">the request for creating service</param>
        Task CreateServiceAsync(CreateServiceRequest request);

        /// <summary>
        /// Updates a service with specified ID.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <param name="request">the request for updating service</param>
        Task UpdateServiceAsync(Guid id, UpdateServiceRequest request);

        /// <summary>
        /// Deletes specified service.
        /// </summary>
        /// <param name="id">the service ID</param>
        Task DeleteServiceAsync(Guid id);
    }
}
