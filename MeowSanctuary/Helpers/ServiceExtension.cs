using MeowSanctuary.Helpers.JwtUtils;
using MeowSanctuary.Helpers.Seeders;
using MeowSanctuary.Repositories;

namespace MeowSanctuary.Helpers
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddScoped<UserSeeder>();
            services.AddScoped<CatSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }

    }
}
