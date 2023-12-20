using TaskManager.Application.Common.Interfaces.Authentication;
using TaskManager.Application.Common.Interfaces.Persistence;
using TaskManager.Application.Services.AuthenticationService.Common;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.AuthenticationService.Queries
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator,
                                     IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(
            string email,
            string password)
        {
            // 1. Validate the user does exits
            if(_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with email not found1");
            }

            // 2. Validate the password is correct
            if(user.Password != password)
            {
                throw new Exception("Invalid password!");
            }

            // 3. Create JWT Token and return it to the user
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
