using AutoCareHub.Data;
using AutoCareHub.Data.Models;
using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl.Appointments;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Services.Impl
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
            try
            {
                var appointments = await _context.Appointments
                    .Include(x => x.User)
                    .Include(x => x.Service)
                    .Include(x => x.MainCategory)
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving appointments.", ex);
            }
        }

        public async Task<Appointment> GetAppointmentAsync(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while retrieving an appointment with specified ID.", ex);
            }
        }

        public async Task CreateAppointmentAsync(CreateAppointmentRequest request)
        {
            try
            {
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var entityAppointment = Conversion.ConvertAppointment(request);

                await _context.Appointments.AddAsync(entityAppointment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while creating an appointment.", ex);
            }
        }

        public async Task UpdateAppointmentAsync(Guid id, UpdateAppointmentRequest request)
        {
            try
            {
                if (request is null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var entity = await _context.Appointments
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (entity is null)
                {
                    throw new ObjectNotFoundException($"Could not find appointment with ID {id}.");
                }

                entity.MainCategoryId = request.MainCategoryId;
                entity.UserId = request.UserId;
                entity.Date = request.Date;
                entity.Description = request.Description;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while updating an appointment with specified ID.", ex);
            }
        }

        public async Task DeleteAppointmentAsync(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                throw new ServiceException("An error occured while deleting an appointment with specified ID.", ex);
            }
        }
    }
}
