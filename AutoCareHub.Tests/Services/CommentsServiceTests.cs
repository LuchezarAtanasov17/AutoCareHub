using AutoCareHub.Services.Comments;
using AutoCareHub.Services.Exceptions;
using AutoCareHub.Services.Impl;
using AutoCareHub.Tests.Mocks;
using ENTITIES = AutoCareHub.Data.Models;

namespace AutoCareHub.Tests.Services
{
    public class CommentsServiceTests
    {
        [Fact]
        public async Task GetComments_ReturnsComment()
        {
            #region Arrange

            var id = Guid.NewGuid();

            using var data = DatabaseMock.Instance;
            data.Comments.Add(new ENTITIES.Comment
            {
                Id = id,
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
            data.Comments.Add(new ENTITIES.Comment
            {
                Id = Guid.NewGuid(),
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
                Value = "TestValue2"

            });

            data.SaveChanges();

            var commentService = new CommentService(data);

            #endregion

            #region Act

            var result = await commentService.GetCommentAsync(id);

            #endregion

            #region Assert

            Assert.NotNull(result);
            Assert.IsType<ENTITIES.Comment>(result);

            #endregion
        }

        [Fact]
        public async Task CreateComment_ThrowsIfCreateCommentRequestIsNull()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var commentService = new CommentService(data);

            #endregion

            #region Act

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await commentService.CreateCommentAsync(null));

            #endregion
        }

        [Fact]
        public async Task CreateComment_DoesNotThrowIfCreateCommentRequestIsFulfilledCorrectly()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var commentService = new CommentService(data);

            var request = new CreateCommentRequest
            {
                ServiceId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Value = "testValue",
            };


            #endregion

            #region Act

            var exception = await Record.ExceptionAsync(async () => await commentService.CreateCommentAsync(request));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }

        [Fact]
        public async Task DeleteComment_ThrowsIfThereIsNoCommentWithThatId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;
            var id = Guid.NewGuid();

            var commentService = new CommentService(data);

            #endregion

            #region Act

            #endregion

            #region Assert

            ServiceException ex = await Assert.ThrowsAsync<ServiceException>(async ()
               => await commentService.DeleteCommentAsync(id));

            //Assert.Equal(ex.Message, $"Could not find an appointment with ID {id}.");

            #endregion
        }

        [Fact]
        public async Task DeleteComment_DoesNotThrowIfThereIsCommentWithGivenId()
        {
            #region Arrange

            using var data = DatabaseMock.Instance;

            var commentService = new CommentService(data);

            var id = Guid.NewGuid();

            data.Comments.Add(new ENTITIES.Comment()
            {
                Id = id,
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

            var exception = await Record.ExceptionAsync(async () => await commentService.DeleteCommentAsync(id));

            #endregion

            #region Assert

            Assert.Null(exception);

            #endregion
        }
    }
}
