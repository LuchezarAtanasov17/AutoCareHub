using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.CreateServiceRequests;
using AutoCareHub.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.ServiceRequests
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly AutoCareHubDbContext _context;

        public ServiceRequestService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ServiceRequest>> ListNotApproved()
        {
            try
            {
                var serviceRequests = await _context.ServiceRequests
                    .Include(x => x.Service)
                    .Include(x => x.Service.User)
                    .Where(x => x.Service.IsApproved == false)
                    .ToListAsync();

                return serviceRequests;
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while retrieving not approved service requests.");
            }
        }

        public async Task Approve(Guid id)
        {
            try
            {
                ServiceRequest? request = await _context.ServiceRequests
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == request.ServiceId);

                if (service is null)
                {
                    throw new ArgumentNullException(nameof(service));
                }

                service.IsApproved = true;

                _context.ServiceRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while approving a service request with specified ID.");
            }
        }

        public async Task Decline(Guid id)
        {
            try
            {
                var request = await _context.ServiceRequests
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var service = await _context.Services
                    .FirstOrDefaultAsync(x => x.Id == request.ServiceId);

                if (service is null)
                {
                    throw new ArgumentNullException(nameof(service));
                }

                _context.ServiceRequests.Remove(request);
                _context.Services.Remove(service);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ServiceException("An error occured while declining a service request with specified ID.");
            }
        }
    }
}
