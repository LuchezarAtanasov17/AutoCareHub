using AutoCareHub.Services.Impl.Users;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task ListSubCategories_ReturnsSubCategories()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            data.Users.Add(new ENTITIES.User()
            {
                Id = Guid.NewGuid(),
                Email = "testEmail@test.com",
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "1234567890",
                UserName = "test",
            });
            data.Users.Add(new ENTITIES.User()
            {
                Id = Guid.NewGuid(),
                Email = "testEmail@test.com",
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "1234567890",
                UserName = "test",
            });

            data.SaveChanges();

            var userService = new UserService(data);

            #endregion

            #region Act

            var result = await userService.ListUsersAsync();

            #endregion

            #region Assert

            Assert.Equal(result.Count, data.Users.Count());
            Assert.IsType<List<ENTITIES.User>>(result);

            #endregion
        }
    }
}
