using Comunidades.ApiService.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Repositories.Contexts
{
    public class AppDbContext : DbContext
    {
        static bool isFirstRun = true;

        public DbSet<UserEntity>? UserEntities { get; set; }
        public DbSet<CommunityEntity>? Communities { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            //EnsureCreated(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userModel = modelBuilder.Entity<UserEntity>();
            var communityModel = modelBuilder.Entity<CommunityEntity>();

            userModel
                .HasIndex(e => e.Email)
                .IsUnique();
            userModel
                .HasMany(e => e.Communities)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);                           

            communityModel
                .HasOne(e => e.Creator)
                .WithMany(e => e.Communities)
                .HasForeignKey(e => e.CreatorId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
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
