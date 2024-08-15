using Comunidades.ApiService.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Comunidades.Tests.Api
{
    /// <summary>
    /// Representa a unidade base para testes unitários.
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// Obtém um mock de AppDbContext.
        /// </summary>
        protected readonly Mock<AppDbContext> AppDbContextMock;

        protected BaseTest() 
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            AppDbContextMock = new Mock<AppDbContext>(optionsBuilder.Options, false);
        }
    }
}
