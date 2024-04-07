using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl.SubCategories;
using AutoCareHub.Services.MainCategories;
using AutoCareHub.Services.SubCategories;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class SubCategoriesServiceTests
    {
        [Fact]
        public async Task ListSubCategories_ReturnsSubCategories()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var id = Guid.NewGuid();

            data.MainCategories.Add(new ENTITIES.MainCategory()
            {
                Id = id,
                Name = "Test",
            });
            data.MainCategories.Add(new ENTITIES.MainCategory()
            {
                Id = Guid.NewGuid(),
                Name = "Test2",
            });

            data.SubCategories.Add(new ENTITIES.SubCategory
            {
                Id = Guid.NewGuid(),
                MainCategoryId = id,
                Name = "TestName",
            });
            data.SubCategories.Add(new ENTITIES.SubCategory
            {
                Id = Guid.NewGuid(),
                MainCategoryId = id,
                Name = "TestName2"
            });

            data.SaveChanges();

            var subCategoryService = new SubCategoryService(data);

            #endregion

            #region Act

            var result = await subCategoryService.ListSubCategoriesAsync();

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.MainCategories.Count());
            Assert.IsType<List<ENTITIES.SubCategory>>(result);

            #endregion
        }

        [Fact]
        public async Task ListCategories_ReturnsSubCategoriesByMainCategoryId()
        {
            #region Arrange

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;

            data.MainCategories.Add(new ENTITIES.MainCategory()
            {
                Id = id,
                Name = "Test",
            });

            data.SubCategories.Add(new ENTITIES.SubCategory
            {
                Id = Guid.NewGuid(),
                MainCategoryId = id,
                Name = "TestName",
            });
            data.SubCategories.Add(new ENTITIES.SubCategory
            {
                Id = Guid.NewGuid(),
                MainCategoryId = id,
                Name = "TestName2"
            });
            data.SubCategories.Add(new ENTITIES.SubCategory
            {
                Id = Guid.NewGuid(),
                MainCategoryId = Guid.NewGuid(),
                Name = "TestName2"
            });

            data.SaveChanges();

            var subCategoryService = new SubCategoryService(data);

            #endregion

            #region Act

            var result = await subCategoryService.ListSubCategoriesAsync(id);

            #endregion

            #region Assert

            Assert.Equal(result.Count, 2);
            Assert.IsType<List<ENTITIES.SubCategory>>(result);

            #endregion
        }

        [Fact]
        public async Task CreateCategory_ThrowsIfCreateMainCategoryRequestIsNull()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var subCategoryService = new SubCategoryService(data);


            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await subCategoryService.CreateSubCategoryAsync(null));

            #endregion
        }

        [Fact]
        public async Task CreateCategory_WorksCorrectlyIfCreateMainCategoryRequestIsFulfilledCorrectly()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var subCategoryService = new SubCategoryService(data);

            var request = new CreateSubCategoryRequest
            {
                MainCategoryId = Guid.NewGuid(),
                Name = "TestName",
            };


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await subCategoryService.CreateSubCategoryAsync(request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task DeleteAppointment_ThrowsIfThereIsNoMainCategoryWithThatId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var subCategoryService = new SubCategoryService(data);

            var id = Guid.NewGuid();

            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await subCategoryService.DeleteSubCategoryAsync(id));

            #endregion
        }

        [Fact]
        public async Task DeleteCategory_WorksCorrectlyIfThereIsMainCategoryWithGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var subCategoryService = new SubCategoryService(data);

            var id = Guid.NewGuid();

            data.SubCategories.Add(new ENTITIES.SubCategory { Id = id, Name = "TestName", MainCategoryId = Guid.NewGuid() });

            data.SaveChanges();


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await subCategoryService.DeleteSubCategoryAsync(id));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }
    }
}
