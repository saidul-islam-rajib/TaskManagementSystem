namespace TaskManager.Application.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationResult Login(
            string email,
            string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstname",
                "lastname",
                email,
                "hardcoded token for testing purpose");
        }

        public AuthenticationResult Register(
            string firstName,
            string lastName,
            string email,
            string password)
        {
           return new AuthenticationResult(
               Guid.NewGuid(),
               firstName,
               lastName,
               email,
               "hard coded token for testing purpose");
        }
    }
}
