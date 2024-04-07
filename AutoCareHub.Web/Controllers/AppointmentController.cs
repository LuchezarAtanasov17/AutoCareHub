using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.Appointment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCareHub.Web.Controllers
{
    /// <summary>
    /// Represents appointment controller.
    /// </summary>
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;

        /// <summary>
        /// Initialize new instance of <see cref="AppointmentController"/> class.
        /// </summary>
        /// <param name="appointmentService"></param>
        /// <param name="serviceService"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AppointmentController(
            IAppointmentService appointmentService,
            IServiceService serviceService)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        /// <summary>
        /// Lists the appointments by service.
        /// </summary>
        /// <param name="serviceId">the service ID</param>
        /// <returns>list view relative to parameters</returns>
        [HttpGet]
        public async Task<IActionResult> ListByService(
            Guid serviceId)
        {
            var entityAppointments = await _appointmentService.ListAppointmentsAsync(serviceId: serviceId);

            List<AppointmentViewModel> appointments = entityAppointments
                .Select(Conversion.ConvertAppointment)
                .ToList();

            return View("ListByService", appointments);
        }

        /// <summary>
        /// Lists the appointments by user.
        /// </summary>
        /// <param name="userId">the user ID</param>
        /// <returns>list view relative to parameters</returns>
        [HttpGet]
        public async Task<IActionResult> ListByUser(
            Guid userId)
        {
            var entityAppointments = await _appointmentService.ListAppointmentsAsync(userId: userId);

            List<AppointmentViewModel> appointments = entityAppointments
                .Select(Conversion.ConvertAppointment)
                .ToList();

            return View("ListByUser", appointments);
        }

        /// <summary>
        /// Creates an appointment.
        /// </summary>
        /// <param name="serviceId">the service ID</param>
        /// <param name="request">the request for creating an appointment</param>
        /// <returns>the list by user view</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost]
        public async Task<IActionResult> Create(
           Guid serviceId,
           CreateAppointmentRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Date < DateTime.Now)
            {
                ModelState.AddModelError(nameof(request.Date), "Invalid date.");
            }
            if (request.Description == null)
            {
                ModelState.AddModelError(nameof(request.Description), "The description field is required.");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get", "Service", new { id = serviceId });
            }

            request.ServiceId = serviceId;
            request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _appointmentService.CreateAppointmentAsync(request);

            return RedirectToAction(nameof(ListByUser), new { userId = request.UserId });
        }

        /// <summary>
        /// Deletes an appointment with specified ID.
        /// </summary>
        /// <param name="id">appointment ID</param>
        /// <param name="serviceId">service ID</param>
        /// <returns>the list by service view</returns>
        public async Task<IActionResult> DeleteByService(Guid id, Guid serviceId)
        {
            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(ListByService), new { serviceId = serviceId });
        }

        /// <summary>
        /// Deletes an appointment with specified ID.
        /// </summary>
        /// <param name="id">appointment ID</param>
        /// <returns>the list by user view</returns>
        public async Task<IActionResult> DeleteByUser(
          [FromRoute]
            Guid id)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(ListByUser), new { userId = userId });
        }
    }
}
