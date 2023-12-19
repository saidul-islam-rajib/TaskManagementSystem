using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Common.Interfaces.Authentication;
using TaskManager.Application.Services.AuthenticationService;
using TaskManager.Infrastructure.Authentication;

namespace TaskManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            return services;
        }
    }
}
