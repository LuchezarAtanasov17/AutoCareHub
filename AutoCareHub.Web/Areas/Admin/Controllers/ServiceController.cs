using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        public ServiceController(
           IServiceService serviceService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var entityServices = await _serviceService
                .ListServicesAsync();

            var services = entityServices
             .Select(Conversion.ConvertService)
             .ToList();

            return View(services);
        }

        public async Task<IActionResult> Delete(
         [FromRoute]
            Guid id)
        {
            await _serviceService.DeleteServiceAsync(id);

            return RedirectToAction(nameof(List));
        }
    }
}
