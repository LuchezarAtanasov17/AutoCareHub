using AutoCareHub.Services.Appointments;
using AutoCareHub.Web.Models.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(
           IAppointmentService appointmentServiceService)
        {
            _appointmentService = appointmentServiceService ?? throw new ArgumentNullException(nameof(appointmentServiceService));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entityAppointments = await _appointmentService.ListAppointmentsAsync();

            List<AppointmentViewModel> appointments = entityAppointments
                .Select(Conversion.ConvertAppointment)
                .ToList();

            return View("List", appointments);
        }

        public async Task<IActionResult> Delete(
            [FromRoute]
            Guid id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
