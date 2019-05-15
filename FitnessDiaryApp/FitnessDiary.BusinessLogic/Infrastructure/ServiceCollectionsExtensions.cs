using FitnessDiary.DataAccess.EF;
using FitnessDiary.DataAccess.Extensions;
using FitnessDiary.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessDiary.BusinessLogic.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection RegisterBllServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);
            services.AddScoped<IFitnessDiaryContext, FitnessDiaryContext>();

            return services;
        }
    }
}
