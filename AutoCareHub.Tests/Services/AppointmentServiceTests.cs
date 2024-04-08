using AutoCareHub.Data.Models;
using AutoCareHub.Services.Appointments;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class AppointmentServiceTests
    {
        [Fact]
        public async Task ListAppointments_ReturnsAppointmentsByUser()
        {
            #region Arrange

            Guid userId = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = Guid.NewGuid(),
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = userId,
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test",
                    City = "TestCity",
                    Address = "TestAddress",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test",
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "Test@gmail.com",
                    PhoneNumber = "0896020441"
                }
            });
            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = Guid.NewGuid(),
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test2",
                    City = "TestCity2",
                    Address = "TestAddress2",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test2",
                    FirstName = "Test2",
                    LastName = "Test2",
                    Email = "Test2@gmail.com",
                    PhoneNumber = "0896020442"
                }
            });

            data.SaveChanges();

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            var result = await appointmentService.ListAppointmentsAsync(userId: userId);

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.Appointments.Where(x => x.UserId == userId).Count());
            Assert.IsType<List<Appointment>>(result);

            #endregion
        }

        [Fact]
        public async Task ListAppointments_ReturnsAppointmentsByService()
        {
            #region Arrange

            Guid serviceId = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = Guid.NewGuid(),
                MainCategoryId = Guid.NewGuid(),
                ServiceId = serviceId,
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test",
                    City = "TestCity",
                    Address = "TestAddress",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test",
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "Test@gmail.com",
                    PhoneNumber = "0896020441"
                }
            });
            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = Guid.NewGuid(),
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test2",
                    City = "TestCity2",
                    Address = "TestAddress2",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test2",
                    FirstName = "Test2",
                    LastName = "Test2",
                    Email = "Test2@gmail.com",
                    PhoneNumber = "0896020442"
                }
            });

            data.SaveChanges();

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            var result = await appointmentService.ListAppointmentsAsync(serviceId: serviceId);

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.Appointments.Where(x => x.ServiceId == serviceId).Count());
            Assert.IsType<List<Appointment>>(result);

            #endregion
        }

        [Fact]
        public async Task GetAppointment_ReturnsAppointment()
        {
            #region Arrange

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;

            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = id,
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test",
                    City = "TestCity",
                    Address = "TestAddress",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test",
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "Test@gmail.com",
                    PhoneNumber = "0896020441"
                }
            });

            data.SaveChanges();

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            var result = await appointmentService.GetAppointmentAsync(id);

            #endregion
            #region Assert

            Assert.NotNull(result);
            Assert.IsType<Appointment>(result);

            #endregion
        }

        [Fact]
        public async Task GetAppointment_ThrowsIfThereIsNoAppointmentWithThatId()
        {
            #region Arrange

            var id = Guid.NewGuid();
            var wrongId = Guid.NewGuid();

            using var data = DatabaseMock.Instance;

            data.Appointments.Add(new ENTITIES.Appointment
            {
                Id = id,
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Service = new ENTITIES.Service
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Name = "Test",
                    City = "TestCity",
                    Address = "TestAddress",
                    OpenTime = TimeOnly.MinValue,
                    CloseTime = TimeOnly.MaxValue,
                },
                User = new ENTITIES.User
                {
                    UserName = "Test",
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "Test@gmail.com",
                    PhoneNumber = "0896020441"
                }
            });

            data.SaveChanges();

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            #endregion
            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
                => await appointmentService.GetAppointmentAsync(wrongId));

            //Assert.Equal(ex.Message, $"Could not find an appointment with ID {wrongId}.");


            #endregion
        }

        [Fact]
        public async Task CreateAppointment_ThrowsIfCreateAppointmentRequestIsNull()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await appointmentService.CreateAppointmentAsync(null));

            #endregion
        }

        [Fact]
        public async Task CreateAppointment_DoesNotThrowIfCreateAppointmentRequestIsFulfilledCorrectly()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var appointmentService = new AppointmentService(data);

            var request = new CreateAppointmentRequest
            {
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "DescriptionTestDescriptionTestDescriptionTest"
            };


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await appointmentService.CreateAppointmentAsync(request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task DeleteAppointment_ThrowsIfThereIsNoAppointmentWithThatId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;
            var id = Guid.NewGuid();

            var appointmentService = new AppointmentService(data);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await appointmentService.DeleteAppointmentAsync(id));

            //Assert.Equal(ex.Message, $"Could not find an appointment with ID {id}.");

            #endregion
        }

        [Fact]
        public async Task DeleteAppointment_DoesNotThrowIfThereIsAppointmentWithGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var appointmentService = new AppointmentService(data);

            var id = Guid.NewGuid();

            data.Appointments.Add(new ENTITIES.Appointment()
            {
                Id = id,
                MainCategoryId = Guid.NewGuid(),
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                MainCategory = new ENTITIES.MainCategory() { Name = "TestName" },
                Service = new ENTITIES.Service()
                {
                    Name = "Name",
                    City = "TestCity",
                    Address = "TestAddress"
                },
                User = new ENTITIES.User()
            });

            data.SaveChanges();


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await appointmentService.DeleteAppointmentAsync(id));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }
    }
}
