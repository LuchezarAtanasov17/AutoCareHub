using AutoCareHub.Data.Models;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Image;
using AutoCareHub.Services.Impl.Services;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Tests.Mocks;
using Microsoft.AspNetCore.Http;
using Moq;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class ServiceServiceTests
    {
        [Fact]
        public async Task ListServices_ReturnsSerivices()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();

            using var data = DatabaseMock.Instance;
            data.Services.Add(new ENTITIES.Service
            {
                UserId = Guid.NewGuid(),
                Name = "Test",
                City = "TestCity",
                Address = "TestAddress",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { }
            });
            data.Services.Add(new ENTITIES.Service
            {
                UserId = Guid.NewGuid(),
                Name = "Test2",
                City = "TestCity2",
                Address = "TestAddress2",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { }
            });

            data.SaveChanges();

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            var result = await serviceService.ListServicesAsync();

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.Services.Count());
            Assert.IsType<List<Service>>(result);

            #endregion
        }

        [Fact]
        public async Task ListServices_ReturnsSerivicesByUserId()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();


            var userId = Guid.NewGuid();

            using var data = DatabaseMock.Instance;

            data.Services.Add(new ENTITIES.Service
            {
                UserId = userId,
                Name = "Test",
                City = "TestCity",
                Address = "TestAddress",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { Id = userId }
            });
            data.Services.Add(new ENTITIES.Service
            {
                UserId = Guid.NewGuid(),
                Name = "Test2",
                City = "TestCity2",
                Address = "TestAddress2",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { }
            });

            data.SaveChanges();

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            var result = await serviceService.ListServicesAsync(userId: userId, allOrMineOption: AllOrMineOption.Mine);

            #endregion

            #region Assert

            Assert.Equal(result.Count, 1);
            Assert.IsType<List<Service>>(result);

            #endregion
        }

        [Fact]
        public async Task GetService_ReturnsSerivice()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            var service = new ENTITIES.Service
            {
                Id = id,
                UserId = Guid.NewGuid(),
                Name = "Test",
                City = "TestCity",
                Address = "TestAddress",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { },
                ImageUrls = string.Empty,
                IsApproved = false,
            };

            data.Services.Add(service);

            data.SaveChanges();

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            var result = await serviceService.GetServiceAsync(id);

            #endregion

            #region Assert

            Assert.Equal(result.City, service.City);
            Assert.Equal(result.Address, service.Address);
            Assert.Equal(result.Name, service.Name);
            Assert.Equal(result.Id, service.Id);
            Assert.Equal(result.OpenTime, service.OpenTime);
            Assert.Equal(result.CloseTime, service.CloseTime);

            Assert.IsType<Service>(result);

            #endregion
        }

        [Fact]
        public async Task GetService_ThrowsIfThereIsNoServiceWithThatId()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            var service = new ENTITIES.Service
            {
                UserId = Guid.NewGuid(),
                Name = "Test",
                City = "TestCity",
                Address = "TestAddress",
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                User = new ENTITIES.User { }
            };

            data.Services.Add(service);

            data.SaveChanges();

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await serviceService.GetServiceAsync(id));

            Assert.Equal("An error occured while retrieving a service with specified ID.", ex.Message);
            #endregion
        }

        [Fact]
        public async Task CreateService_DoesNotThrowIfCreateServiceRequestIsFulfilledCorrectly()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            var request = new CreateServiceRequest
            {
                UserId = Guid.NewGuid(),
                Name = "Test",
                City = "TestCity",
                Address = "TestAddress",
                OpenTime = TimeOnly.MinValue.ToString(),
                CloseTime = TimeOnly.MaxValue.ToString(),
                MainCategoryIds = new List<Guid>() { Guid.NewGuid() },
                Images = new List<Microsoft.AspNetCore.Http.IFormFile>(),
            };


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await serviceService.CreateServiceAsync(request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task CreateService_ThrowsIfCreateServiceRequestIsNull()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await serviceService.CreateServiceAsync(null));

            Assert.Equal("An error occured while creating a service.", ex.Message);

            #endregion
        }

        [Fact]
        public async Task UpdateService_DoesNotThrowIfUpdateServiceRequestIsFulfilledCorrectly()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var serviceService = new ServiceService(data, imageServiceMock.Object);
            var id = Guid.NewGuid();


            data.Services.Add(new ENTITIES.Service()
            {
                Id = id,
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                Name = "TestName",
                City = "TestCity",
                Address = "TestAddress",
            });

            data.SaveChanges();

            var request = new UpdateServiceRequest
            {
                OpenTime = TimeOnly.MinValue.ToString(),
                CloseTime = TimeOnly.MaxValue.ToString(),
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                Name = "TestName",
                City = "TestCity",
                Address = "TestAddress",
                SelectMainCategory = new List<SelectMainCategory>()
                {
                    new SelectMainCategory()
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestName",
                    }
                }
            };

            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await serviceService.UpdateServiceAsync(id, request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task UpdateService_ThrowsIfUpdateServiceRequestIsNull()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await serviceService.UpdateServiceAsync(Guid.NewGuid(), null));

            Assert.Equal("An error occured while updating a service with specified ID.", ex.Message);
            #endregion
        }

        [Fact]
        public async Task UpdateService_ThrowsIfThereIsNoServiceWithGivenId()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var id = Guid.NewGuid();

            data.Services.Add(new ENTITIES.Service()
            {
                Id = Guid.NewGuid(),
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                Name = "TestName",
                City = "TestCity",
                Address = "TestAddress",
            });

            data.SaveChanges();

            var request = new UpdateServiceRequest
            {
                OpenTime = TimeOnly.MinValue.ToString(),
                CloseTime = TimeOnly.MaxValue.ToString(),
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                Name = "TestName",
                City = "TestCity",
                Address = "TestAddress",
                SelectMainCategory = new List<SelectMainCategory>()
                {
                    new SelectMainCategory()
                    {
                        Id = Guid.NewGuid(),
                        Name = "TestName",
                    }
                }
            };

            var serviceService = new ServiceService(data, imageServiceMock.Object);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await serviceService.UpdateServiceAsync(id, request));

            Assert.Equal("An error occured while updating a service with specified ID.", ex.Message);
            #endregion
        }

        [Fact]
        public async Task DeleteService_DoesNotThrowIfThereIsServiceWithGivenId()
        {
            #region Arrange
            MockRepository _mockRepository = new MockRepository(MockBehavior.Loose);
            Mock<IImageService> imageServiceMock = _mockRepository.Create<IImageService>();
            using var data = DatabaseMock.Instance;

            var serviceService = new ServiceService(data, imageServiceMock.Object);
            var id = Guid.NewGuid();

            data.Services.Add(new ENTITIES.Service()
            {
                Id = id,
                OpenTime = TimeOnly.MinValue,
                CloseTime = TimeOnly.MaxValue,
                Description = "DescriptionTestDescriptionTestDescriptionTest",
                Name = "TestName",
                City = "TestCity",
                Address = "TestAddress",
            });

            data.SaveChanges();

            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await serviceService.DeleteServiceAsync(id));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }
    }
}
