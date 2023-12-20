using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.AuthenticationService
{
    // Creating object for the result
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}
