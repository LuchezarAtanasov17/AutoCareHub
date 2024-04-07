using AutoCareHub.Data.Models;
using AutoCareHub.Services.CreateServiceRequests;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.ServiceRequests;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// Represents service request controller.
    /// </summary>
    public class ServiceRequestController : BaseController
    {
        private readonly IServiceRequestService _serviceRequestService;

        /// <summary>
        /// Initialize new instance of <see cref="ServiceRequestController"/> class.
        /// </summary>
        /// <param name="serviceRequestService">the service request service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ServiceRequestController(
           IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService ?? throw new ArgumentNullException(nameof(serviceRequestService));
        }

        /// <summary>
        /// Lists service requests.
        /// </summary>
        /// <returns>the list service requests view</returns>
        [HttpGet]
        public async Task<IActionResult> List()
        {
            List<ServiceRequest> entityRequests = await _serviceRequestService
                .ListNotApproved();

            var requests = entityRequests
                .Select(Conversion.ConvertServiceRequest)
                .ToList();

            return View(requests);
        }

        /// <summary>
        /// Declines a specified service request.
        /// </summary>
        /// <param name="id">the service request ID</param>
        /// <returns>the list service requests view</returns>
        public async Task<IActionResult> Decline(
            [FromRoute]
            Guid id)
        {
            await _serviceRequestService.Decline(id);

            return RedirectToAction(nameof(List));
        }

        /// <summary>
        /// Approves a specified service request.
        /// </summary>
        /// <param name="id">the service request ID</param>
        /// <returns>the list service requests view</returns>
        [HttpGet]
        public async Task<IActionResult> Approve(
            [FromRoute]
            Guid id)
        {
            await _serviceRequestService.Approve(id);

            return RedirectToAction(nameof(List));
        }
    }
}
