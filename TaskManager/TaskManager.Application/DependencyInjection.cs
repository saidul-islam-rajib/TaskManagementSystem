using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Services.AuthenticationService;

namespace TaskManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
