using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.Services;
using AutoCareHub.Services.SubCategories;
using AutoCareHub.Services.Users;
using AutoCareHub.Web.Controllers;
using AutoCareHub.Web.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Routing;
using Moq;

namespace AutoCareHub.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly MockRepository _mockRepository;
        private readonly Mock<IServiceService> serviceServiceMock;
        private readonly Mock<IMainCategoryService> mainCategoryServiceMock;
        private readonly Mock<ISubCategoryService> subCategoryServiceMock;
        private readonly Mock<IUserService> userServiceMock;

        public HomeControllerTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);
            serviceServiceMock = _mockRepository.Create<IServiceService>();
            mainCategoryServiceMock = _mockRepository.Create<IMainCategoryService>();
            subCategoryServiceMock = _mockRepository.Create<ISubCategoryService>();
            userServiceMock = _mockRepository.Create<IUserService>();
        }

        [Fact]
        public void IndexHome_ReturnView()
        {
            #region Arrange

            #endregion

            #region Act

            var controller = new HomeController(serviceServiceMock.Object, mainCategoryServiceMock.Object, userServiceMock.Object, subCategoryServiceMock.Object);
            var result = controller.Index();

            #endregion

            #region Assert

            Assert.NotNull(result);

            #endregion
        }

        [Fact]
        public void ObjectNotFoundException_ReturnView()
        {
            #region Arrange

            var featureCollectionMock = _mockRepository.Create<IFeatureCollection>();

            featureCollectionMock.Setup(x => x.Get<IExceptionHandlerFeature>())
                .Returns(new ExceptionHandlerFeature
                {
                    Path = "/",
                    Error = new ObjectNotFoundException("Test Message")
                });

            var httpContextMock = _mockRepository.Create<HttpContext>();
            httpContextMock.Setup(x => x.Features).Returns(featureCollectionMock.Object);

            #endregion

            #region Act

            var context = new ControllerContext(new ActionContext(httpContextMock.Object, new RouteData(), new ControllerActionDescriptor()));
            var controller = new HomeController(serviceServiceMock.Object, mainCategoryServiceMock.Object, userServiceMock.Object, subCategoryServiceMock.Object)
            {
                ControllerContext = context
            };

            var result = controller.Error();

            #endregion

            #region Assert

            Assert.NotNull(result);

            var expected = result as ViewResult;

            Assert.NotNull(expected);

            var errorViewModelResult = expected.Model as ErrorViewModel;

            Assert.NotNull(errorViewModelResult);

            Assert.Equal(404, errorViewModelResult.StatusCode);
            Assert.Equal("Test Message", errorViewModelResult.Message);

            #endregion
        }

        [Fact]
        public void Exception_ReturnView()
        {
            #region Arrange

            var featureCollectionMock = _mockRepository.Create<IFeatureCollection>();

            featureCollectionMock.Setup(x => x.Get<IExceptionHandlerFeature>())
                .Returns(new ExceptionHandlerFeature
                {
                    Path = "/",
                    Error = new Exception("Test Message")
                });

            var httpContextMock = _mockRepository.Create<HttpContext>();
            httpContextMock.Setup(x => x.Features).Returns(featureCollectionMock.Object);

            #endregion

            #region Act

            var context = new ControllerContext(new ActionContext(httpContextMock.Object, new RouteData(), new ControllerActionDescriptor()));
            var controller = new HomeController(serviceServiceMock.Object, mainCategoryServiceMock.Object, userServiceMock.Object, subCategoryServiceMock.Object)
            {
                ControllerContext = context
            };

            var result = controller.Error();

            #endregion

            #region Assert

            Assert.NotNull(result);

            var expected = result as ViewResult;

            Assert.NotNull(expected);

            var errorViewModelResult = expected.Model as ErrorViewModel;

            Assert.NotNull(errorViewModelResult);

            Assert.Equal(500, errorViewModelResult.StatusCode);
            Assert.Equal("Test Message", errorViewModelResult.Message);

            #endregion
        }
    }
}
