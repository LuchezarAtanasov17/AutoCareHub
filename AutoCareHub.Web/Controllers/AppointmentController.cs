using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.Appointment;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoCareHub.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceService _serviceService;
        private readonly IMainCategoryService _mainCategoryService;

        public AppointmentController(
            IAppointmentService appointmentService,
            IServiceService serviceService,
            IMainCategoryService mainCategoryService)
        {
            _appointmentService = appointmentService ?? throw new ArgumentNullException(nameof(appointmentService));
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
            _mainCategoryService = mainCategoryService ?? throw new ArgumentNullException(nameof(mainCategoryService));

        }

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

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentAsync(id);

            var model = new UpdateAppointmentRequest()
            {
                UserId = appointment.UserId,
                MainCategoryId = appointment.MainCategoryId,
                Description = appointment.Description,
                Date = appointment.Date,
                ServiceName = appointment.Service.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id, UpdateAppointmentRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (request.Date < DateTime.Now)
            {
                ModelState.AddModelError(nameof(request.Date), "Invalid date.");
            }

            if (!ModelState.IsValid)
            {
                return View("Update", request);
            }

            request.UserId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _appointmentService.UpdateAppointmentAsync(id, request);

            return RedirectToAction(nameof(ListByUser), new { userId = request.UserId });
        }

        public async Task<IActionResult> DeleteByService(
            [FromRoute]
            Guid id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);

            return RedirectToAction(nameof(ListByService), new { serviceId = id });
        }

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
