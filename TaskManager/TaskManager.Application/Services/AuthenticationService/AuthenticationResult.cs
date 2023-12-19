namespace TaskManager.Application.Services.AuthenticationService
{
    // Creating object for the result
    public record AuthenticationResult
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
