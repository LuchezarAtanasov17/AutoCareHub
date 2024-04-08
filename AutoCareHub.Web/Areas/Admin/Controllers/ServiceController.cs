using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents service controller.
    /// </summary>
    public class ServiceController : BaseController
    {
        private readonly IServiceService _serviceService;

        /// <summary>
        /// Initialize new instance of <see cref="ServiceController"/> class.
        /// </summary>
        /// <param name="serviceService">the service service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceController(
           IServiceService serviceService)
        {
            _serviceService = serviceService ?? throw new ArgumentNullException(nameof(serviceService));
        }

        /// <summary>
        /// Lists services.
        /// </summary>
        /// <returns>the list services view</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var entityServices = await _serviceService
                    .ListServicesAsync();

                var services = entityServices
                 .Select(Conversion.ConvertService)
                 .ToList();

                return View(services);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Dleetes a specified service.
        /// </summary>
        /// <param name="id">the service ID</param>
        /// <returns>the list services view</returns>
        public async Task<IActionResult> Delete(
         [FromRoute]
            Guid id)
        {
            try
            {
                await _serviceService.DeleteServiceAsync(id);

                return RedirectToAction(nameof(List));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
