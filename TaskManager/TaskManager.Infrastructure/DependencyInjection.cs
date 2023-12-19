using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Services.AuthenticationService;

namespace TaskManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
