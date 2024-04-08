using AutoCareHub.Services.Appointments;
using AutoCareHub.Web.Models.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents appointment controller.
    /// </summary>
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;

        /// <summary>
        /// Initialize new instance of <see cref="AppointmentController"/> class.
        /// </summary>
        /// <param name="appointmentServiceService">the appointment service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public AppointmentController(
           IAppointmentService appointmentServiceService)
        {
            _appointmentService = appointmentServiceService ?? throw new ArgumentNullException(nameof(appointmentServiceService));
        }

        /// <summary>
        /// Lists appointments.
        /// </summary>
        /// <returns>the list appointments view</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var entityAppointments = await _appointmentService.ListAppointmentsAsync();

                List<AppointmentViewModel> appointments = entityAppointments
                    .Select(Conversion.ConvertAppointment)
                    .ToList();

                return View("List", appointments);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Deletes a specified appointment.
        /// </summary>
        /// <param name="id">the appointment ID</param>
        /// <returns>the list appointments view</returns>
        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            try
            {
                await _appointmentService.DeleteAppointmentAsync(id);

                return RedirectToAction(nameof(List));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
