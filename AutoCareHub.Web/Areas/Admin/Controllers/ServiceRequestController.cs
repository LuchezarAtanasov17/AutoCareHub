using AutoCareHub.Data.Models;
using AutoCareHub.Services.CreateServiceRequests;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Models.ServiceRequests;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace AutoCareHub.Web.Areas.Admin.Controllers
{
    public class ServiceRequestController : BaseController
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestController(
           IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService ?? throw new ArgumentNullException(nameof(serviceRequestService));
        }

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

        public async Task<IActionResult> Decline(
            [FromRoute]
            Guid id)
        {
            await _serviceRequestService.Decline(id);

            return RedirectToAction(nameof(List));
        }

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
