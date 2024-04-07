using AutoCareHub.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoCareHub.Tests.Mocks
{
    public static class DatabaseMock
    {
        public static AutoCareHubDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<AutoCareHubDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new AutoCareHubDbContext(dbContextOptions);
            }
        }
    }
}
