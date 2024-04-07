using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl.Likes;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class LikeServiceTests
    {
        [Fact]
        public async Task LikeComment_DoesNotThrowIfInformationIsFulfilledCorrectly()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var likeService = new LikeService(data);

            var commentId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            data.Comments.Add(new ENTITIES.Comment
            {
                Id = commentId,
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
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
                },
                PublishedOn = DateTime.UtcNow,
                Value = "TestValue"
            });

            data.Users.Add(new ENTITIES.User()
            {
                Id = userId,
                UserName = "Test",
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@gmail.com",
                PhoneNumber = "0896020441",
            });

            data.SaveChanges();

            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await likeService.HandleLikeCommentAsync(commentId, userId));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task LikeComment_ThrowsIfThereIsNoUserWithTheGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var likeService = new LikeService(data);

            var commentId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            data.Comments.Add(new ENTITIES.Comment
            {
                Id = commentId,
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
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
                },
                PublishedOn = DateTime.UtcNow,
                Value = "TestValue"
            });

            data.SaveChanges();

            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await likeService.HandleLikeCommentAsync(commentId, userId));

            #endregion
        }

        [Fact]
        public async Task LikeComment_ThrowsIfThereIsNoCommentWithTheGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var likeService = new LikeService(data);

            var commentId = Guid.NewGuid();
            var userId = Guid.NewGuid();

            data.Likes.Add(new ENTITIES.Like()
            {
                Id = Guid.NewGuid(),
                CommentId = commentId,
                UserId = userId,
            });

            data.SaveChanges();

            #endregion

            #region Act

            await likeService.HandleLikeCommentAsync(commentId, userId);

            #endregion

            #region Assert

            Assert.Equal(0, data.Likes.Count());

            #endregion
        }
    }
}
