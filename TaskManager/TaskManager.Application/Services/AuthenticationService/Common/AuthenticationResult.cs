using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.AuthenticationService.Common
{
    // Creating object for the result
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
