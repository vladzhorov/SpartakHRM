using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SpartakHRM.UserService.DAL;

namespace SpartakHRM.IntegrationTest.Helpers
{
    public class DatabaseFixture : IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        protected ServiceProvider _serviceProvider;

        public const string ExistingUserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";

        public const string UpdateUserId = "889d3c5c-f357-439f-a685-e19bad77ef03";

        public DatabaseFixture()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(ConfigureServices);

            });
        }

        private void ConfigureServices(IServiceCollection services)
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<AppDbContext>)
            );
            if (dbContextDescriptor != null)
            {
                services.Remove(dbContextDescriptor);
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestDatabase");
            });

            _serviceProvider = services.BuildServiceProvider();

            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public HttpClient CreateClient()
        {
            return _factory.CreateClient();
        }

        public void Dispose()
        {
            _factory?.Dispose();
            _serviceProvider?.Dispose();
        }
    }
}
