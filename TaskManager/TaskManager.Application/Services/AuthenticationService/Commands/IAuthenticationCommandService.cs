using TaskManager.Application.Services.AuthenticationService.Common;

namespace TaskManager.Application.Services.AuthenticationService.Commands
{
    public interface IAuthenticationCommandService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
