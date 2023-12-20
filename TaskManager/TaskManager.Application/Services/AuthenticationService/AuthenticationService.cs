﻿using TaskManager.Application.Common.Interfaces.Authentication;
using TaskManager.Application.Common.Interfaces.Persistence;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
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

        public AuthenticationResult Register(
            string firstName,
            string lastName,
            string email,
            string password)
        {
            // 1. Validate the user doesn't exits
            if(_userRepository.GetUserByEmail(email) != null)
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
