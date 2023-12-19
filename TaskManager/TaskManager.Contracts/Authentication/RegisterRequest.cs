namespace TaskManager.Contracts.Authentication
{
    // to register, user's must fill those filds that given below
    public record RegisterRequest
    (
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}
