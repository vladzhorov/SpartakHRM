using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SpartakHRM.UserService.DAL.Entities;

namespace SpartakHRM.UserService.DAL
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<OfficeEntity> Offices { get; set; }
        //public DbSet<UserDraftEntity> Drafts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            System.Diagnostics.Debug.WriteLine(_configuration);
        }

        // Other configuration methods, if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure your entity mappings and relationships

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserEntity>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnUpdate();

            modelBuilder.Entity<OfficeEntity>()
                .Property(u => u.CreatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<OfficeEntity>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValue(DateTime.UtcNow)
                .ValueGeneratedOnUpdate();

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

        }
    }
}
