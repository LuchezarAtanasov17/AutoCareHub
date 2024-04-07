using AutoCareHub.Data.Models;
using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Web.Controllers;
using AutoCareHub.Web.Models.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Moq;
using System.Security.Claims;

namespace AutoCareHub.Tests.Controllers
{
    public class AppointmentControllerTests
    {
        private readonly Claim nameIdentifier = new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString());

        private readonly MockRepository _mockRepository;
        private readonly Mock<IAppointmentService> appointmentServiceMock;
        private readonly Mock<IServiceService> serviceServiceMock;
        private readonly Mock<HttpContext> httpContextMock;

        public AppointmentControllerTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            appointmentServiceMock = _mockRepository.Create<IAppointmentService>();
            serviceServiceMock = _mockRepository.Create<IServiceService>();

            httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(m => m.User.FindFirst(ClaimTypes.NameIdentifier)).Returns(nameIdentifier);
        }

        [Fact]
        public async Task ListByServiceAppointments_ReturnsViewWithAppointmentsByService()
        {
            #region Arrange

            var serviceId = Guid.NewGuid();

            var serviceAppointments = new List<Appointment>()
            {
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    MainCategoryId= Guid.NewGuid(),
                    Description= "Test2",
                    Date= DateTime.Now,
                    ServiceId = serviceId,
                    UserId= Guid.NewGuid(),
                    User = new User(),
                    Service = new Service(),
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    MainCategoryId= Guid.NewGuid(),
                    Description= "Test",
                    Date= DateTime.Now,
                    ServiceId = Guid.NewGuid(),
                    UserId= Guid.NewGuid(),
                    User = new User(),
                    Service = new Service(),
                }
            };

            appointmentServiceMock.Setup(x => x.ListAppointmentsAsync(
                    It.IsAny<Guid?>(), It.IsAny<Guid?>()))
                .Returns(Task.FromResult(serviceAppointments));

            #endregion

            #region Act

            var controller = new AppointmentController
                (appointmentServiceMock.Object, serviceServiceMock.Object);

            var result = await controller.ListByService(serviceId);

            #endregion

            #region Assert

            Assert.NotNull(result);

            var expected = result as ViewResult;

            Assert.NotNull(expected);

            Assert.IsType<List<AppointmentViewModel>>(expected.Model);

            var controllerAppointments = expected.Model as List<AppointmentViewModel>;

            List<Guid> controllerItemIds = controllerAppointments!.Select(x => x.Id).ToList();
            List<Guid> serviceItemIds = serviceAppointments!.Select(x => x.Id).ToList();

            List<Guid> missingIds = serviceItemIds.Except(controllerItemIds).ToList();
            List<Guid> unexpectedIds = controllerItemIds.Except(serviceItemIds).ToList();

            Assert.Empty(missingIds);
            Assert.Empty(unexpectedIds);

            #endregion
        }

        [Fact]
        public async Task DeleteAppointmentByService_RedirectsToListAppointmentsByService()
        {
            #region Arrange

            appointmentServiceMock.Setup(x => x.DeleteAppointmentAsync(
                    It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            #endregion

            #region Act

            var controller = new AppointmentController(appointmentServiceMock.Object, serviceServiceMock.Object);

            var result = await controller.DeleteByService(Guid.NewGuid(), Guid.NewGuid());

            #endregion

            #region Assert

            Assert.NotNull(result);

            var expected = result as RedirectToActionResult;
            Assert.NotNull(expected);
            Assert.Equal("ListByService", expected.ActionName);

            #endregion
        }

        [Fact]
        public async Task DeleteMyAppointment_RedirectsToListMyAppointments()
        {
            #region Arrange

            appointmentServiceMock.Setup(x => x.DeleteAppointmentAsync(
                    It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            #endregion

            #region Act

            var context = new ControllerContext(new ActionContext(httpContextMock.Object, new RouteData(), new ControllerActionDescriptor()));
            var controller = new AppointmentController(appointmentServiceMock.Object, serviceServiceMock.Object)
            {
                ControllerContext = context
            };

            var result = await controller.DeleteByUser(Guid.NewGuid());

            #endregion

            #region Assert

            Assert.NotNull(result);

            var expected = result as RedirectToActionResult;
            Assert.NotNull(expected);
            Assert.Equal("ListByUser", expected.ActionName);

            #endregion
        }
    }
}
