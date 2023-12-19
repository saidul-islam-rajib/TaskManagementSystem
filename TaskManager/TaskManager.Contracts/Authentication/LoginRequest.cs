namespace TaskManager.Contracts.Authentication
{
    // Login request will have email and password to log into the system
    public record LoginRequest
    (
        string Email,
        string Password
    );
}
