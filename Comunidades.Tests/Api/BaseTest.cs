using Comunidades.ApiService.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Comunidades.Tests.Api
{
    public class BaseTest
    {
        protected readonly Mock<AppDbContext> AppDbContextMock;

        protected BaseTest() 
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            AppDbContextMock = new Mock<AppDbContext>(optionsBuilder.Options, false);
        }
    }
}
