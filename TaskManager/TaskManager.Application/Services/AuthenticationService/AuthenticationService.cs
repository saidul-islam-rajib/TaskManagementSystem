using TaskManager.Application.Common.Interfaces.Authentication;

namespace TaskManager.Application.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

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
            // Going to check user already exits or not

            // Create user if not exits

            // Create JWT Token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

           return new AuthenticationResult(
               userId,
               firstName,
               lastName,
               email,
               token);
        }
    }
}
