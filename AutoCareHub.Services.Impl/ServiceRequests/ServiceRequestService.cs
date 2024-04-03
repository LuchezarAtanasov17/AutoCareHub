using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.CreateServiceRequests;
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
            var serviceRequests = await _context.ServiceRequests
                .Include(x=>x.Service)
                .Include(x=>x.Service.User)
                .Where(x => x.Service.IsApproved == false)
                .ToListAsync();

            return serviceRequests;
        }

        public async Task Approve(Guid id)
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

        public async Task Decline(Guid id)
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
    }
}
