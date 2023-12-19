namespace TaskManager.Contracts.Authentication
{
    // Authentication response
    public record AuthenticationResponse
    (
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
