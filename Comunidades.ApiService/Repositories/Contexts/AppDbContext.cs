using Comunidades.ApiService.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Repositories.Contexts
{
    public class AppDbContext : DbContext
    {
        static bool isFirstRun = true;

        public DbSet<UserEntity>? UserEntities { get; set; }
        public DbSet<CommunityEntity>? Communities { get; set; }
        public DbSet<UserLoginRegistryEntity> UserLoginRegistries { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            //EnsureCreated(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userModel = modelBuilder.Entity<UserEntity>();
            var communityModel = modelBuilder.Entity<CommunityEntity>();
            var userLoginRegistryModel = modelBuilder.Entity<UserLoginRegistryEntity>();

            userModel
                .HasIndex(e => e.Email)
                .IsUnique();
            userModel
                .HasMany(e => e.Communities)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId);                     
            userModel
                .HasMany(e => e.LoginRegisters)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            communityModel
                .HasOne(e => e.Creator)
                .WithMany(e => e.Communities)
                .HasForeignKey(e => e.CreatorId)
                .IsRequired();

            userLoginRegistryModel
                .HasOne(e => e.User)
                .WithMany(e => e.LoginRegisters)
                .HasForeignKey(e => e.UserId)
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
