using Comunidades.ApiService.Repositories.Contexts;

namespace Comunidades.ApiService.Repositories
{
    /// <summary>
    /// Representa repositório base para implementações com Microsoft.EntityFramework.DbContext.
    /// </summary>
    public class DbContextRepository
    {
        protected AppDbContext appContext;

        public AppDbContext AppDbContext { get { return appContext; } }

        public DbContextRepository(AppDbContext appContext)
        {
            this.appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }
    }
}
