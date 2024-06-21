using DotNet8WebApi.HexagonalWithResultPattern.DbService.AppDbContexts;
using DotNet8WebApi.HexagonalWithResultPattern.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.HexagonalWithResultPattern
{
    public static class ModularService
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextServices(builder);
            services.AddRepositoriesServices();
            services.AddBusinessLogicServices();
            services.AddJsonServices();

            return services;
        }

        private static IServiceCollection AddDbContextServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();
            return services;
        }

        private static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogRepository, BlogRepository>();
            return services;
        }

        private static IServiceCollection AddJsonServices(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            return services;
        }
    }
}
