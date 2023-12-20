using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Services.AuthenticationService.Commands;
using TaskManager.Application.Services.AuthenticationService.Queries;

namespace TaskManager.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}
