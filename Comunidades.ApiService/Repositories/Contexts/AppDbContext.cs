using Comunidades.ApiService.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Repositories.Contexts
{
    public class AppDbContext : DbContext
    {
        static bool isFirstRun = true;

        public DbSet<UserEntity>? UserEntities { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            EnsureCreated(this);
        }

        public static void EnsureCreated(AppDbContext context)
        {
            if (isFirstRun)
            {
                try
                {
                    context.Database.EnsureCreated();
                }
                catch
                {

                }
                finally
                {
                    isFirstRun = false;
                }
            }
        }
    }
}
