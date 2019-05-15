using FitnessDiary.DataAccess.EF;
using FitnessDiary.DataAccess.Interfaces;
using FitnessDiary.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessDiary.DataAccess.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(DbContext), typeof(FitnessDiaryContext));
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<FitnessDiaryContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                });

            return services;
        }
    }
}
