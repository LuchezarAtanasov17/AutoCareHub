using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Appointments;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AutoCareHubDbContext _context;

        public AppointmentService(AutoCareHubDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Appointment>> ListAppointmentsAsync(Guid? serviceId = null, Guid? userId = null)
        {
            var appointments = await _context.Appointments
                .Include(x => x.User)
                .Include(x => x.Service)
                .ToListAsync();

            if (serviceId != null)
            {
                appointments = appointments
                    .Where(x => x.ServiceId == serviceId)
                    .ToList();
            }
            if (userId != null)
            {
                appointments = appointments
                    .Where(x => x.UserId == userId)
                    .ToList();
            }

            return appointments;
        }

        public async Task<Appointment> GetAppointmentAsync(Guid id)
        {
            var appointment = await _context.Appointments
                .Include(x => x.Service)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (appointment is null)
            {
                throw new ObjectNotFoundException($"Could not find an appointment with ID {id}.");
            }

            return appointment;
        }

        public async Task CreateAppointmentAsync(CreateAppointmentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            await _context.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAppointmentAsync(Guid id, UpdateAppointmentRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new ObjectNotFoundException($"Could not find appointment with ID {id}.");
            }

            entity.UserId = request.UserId;
            entity.MainCategoryId = request.MainCategoryId;
            entity.UserId = request.UserId;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.Description = request.Description;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            var entity = await _context.Appointments
                  .FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
            {
                throw new ObjectNotFoundException($"Could not find an appointment with ID {id}.");
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
