using Comunidades.ApiService.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Repositories.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserEntity>? UserEntities { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    }
}
