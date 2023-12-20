using TaskManager.Application.Common.Interfaces.Authentication;
using TaskManager.Application.Common.Interfaces.Persistence;
using TaskManager.Application.Services.AuthenticationService.Common;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.AuthenticationService.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator,
                                     IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Register(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            // 1. Validate the user doesn't exits
            if (_userRepository.GetUserByEmail(email) != null)
            {
                throw new Exception("user with given email already exists");
            }

            // 2. Create user (generate unique ID) and persist to DB
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            // 3. Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
