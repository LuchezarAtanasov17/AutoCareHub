using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl.MainCategories;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class MainmainCategoryServiceTests
    {
        [Fact]
        public async Task ListCategories_ReturnsMainCategories()
        {
            #region Arrange


            using var data = DatabaseMock.Instance;
            data.MainCategories.Add(new ENTITIES.MainCategory
            {
                Name = "TestName",
            });
            data.MainCategories.Add(new ENTITIES.MainCategory
            {
                Name = "TestName2"
            });

            data.SaveChanges();

            var mainCategoryService = new MainCategoryService(data);

            #endregion

            #region Act

            var result = await mainCategoryService.ListMainCategoriesAsync();

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.MainCategories.Count());
            Assert.IsType<List<ENTITIES.MainCategory>>(result);

            #endregion
        }

        [Fact]
        public async Task ListCategories_ReturnsMainCategoriesByServiceId()
        {
            #region Arrange

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            data.MainCategories.Add(new ENTITIES.MainCategory
            {
                Name = "TestName",
            });
            data.MainCategories.Add(new ENTITIES.MainCategory
            {
                Id = id,
                Name = "TestName2"
            });

            data.SaveChanges();

            data.MainCategoryServices.Add(new ENTITIES.MainCategoryService
            {
                ServiceId = id,
                MainCategoryId = Guid.NewGuid(),
                MainCategory = data.MainCategories.First(x => x.Name == "TestName2"),
            });

            data.SaveChanges();

            var mainCategoryService = new MainCategoryService(data);

            #endregion

            #region Act

            var result = await mainCategoryService.ListMainCategoriesAsync(id);

            #endregion

            #region Assert

            Assert.Equal(result.Count, 1);
            Assert.IsType<List<ENTITIES.MainCategory>>(result);

            #endregion
        }

        [Fact]
        public async Task CreateCategory_ThrowsIfCreateMainCategoryRequestIsNull()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var mainCategoryService = new MainCategoryService(data);


            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await mainCategoryService.CreateMainCategoryAsync(null));

            #endregion
        }

        [Fact]
        public async Task CreateCategory_WorksCorrectlyIfCreateMainCategoryRequestIsFulfilledCorrectly()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var mainCategoryService = new MainCategoryService(data);

            var request = new CreateMainCategoryRequest
            {
                Name = "TestName",
            };


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await mainCategoryService.CreateMainCategoryAsync(request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task DeleteMainCategory_ThrowsIfThereIsNoMainCategoryWithThatId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var mainCategoryService = new MainCategoryService(data);

            var id = Guid.NewGuid();

            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await mainCategoryService.DeleteMainCategoryAsync(id));

            #endregion
        }

        [Fact]
        public async Task DeleteCategory_WorksCorrectlyIfThereIsMainCategoryWithGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var mainCategoryService = new MainCategoryService(data);

            var id = Guid.NewGuid();

            data.MainCategories.Add(new ENTITIES.MainCategory { Id = id, Name = "TestName" });

            data.SaveChanges();


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await mainCategoryService.DeleteMainCategoryAsync(id));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }
    }
}
