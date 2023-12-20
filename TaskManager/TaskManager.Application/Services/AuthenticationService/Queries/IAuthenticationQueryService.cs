using TaskManager.Application.Services.AuthenticationService.Common;

namespace TaskManager.Application.Services.AuthenticationService.Queries
{
    public interface IAuthenticationQueryService
    {
        AuthenticationResult Login(string email, string password);
    }
}
