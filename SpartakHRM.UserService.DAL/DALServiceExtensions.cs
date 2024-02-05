using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SpartakHRM.UserService.DAL.Entities;
using SpartakHRM.UserService.DAL.Interface;
using SpartakHRM.UserService.DAL.Interfaces;
using SpartakHRM.UserService.DAL.Repositories;

namespace SpartakHRM.UserService.DAL
{
    public static class DALServiceExtensions
    {
        public static void AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseOptions>(options => configuration.GetSection(nameof(DatabaseOptions)).Bind(options));


            services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var dbOptions = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

                options.UseNpgsql(dbOptions.ConnectionString,
                    b => b.MigrationsAssembly("SpartakHRM.UserService.DAL"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IRepository<DocumentEntity>, DocumentRepository>();
            //services.AddScoped<IUserDraftRepository, UserDraftRepository>();
        }
    }
}