﻿using AutoCareHub.Data.Models;
using AutoCareHub.Web.Model.Services;

namespace AutoCareHub.Services.Services
{
    public interface IServiceService
    {
        Task<List<Service>> ListServicesAsync(Guid? userId = null);

        Task<Service> GetServiceAsync(Guid id);

        Task CreateServiceAsync(CreateServiceRequest request);

        Task UpdateServiceAsync(Guid id, UpdateServiceRequest request);

        Task DeleteServiceAsync(Guid id);
    }
}