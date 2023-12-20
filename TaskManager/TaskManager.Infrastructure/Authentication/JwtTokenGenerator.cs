using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManager.Application.Common.Interfaces.Authentication;
using TaskManager.Application.Common.Interfaces.Services;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly Jwtsettings _jwtsettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<Jwtsettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtsettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtsettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Create the security token
            var securityToken = new JwtSecurityToken(
                issuer:_jwtsettings.issuer,
                audience: _jwtsettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtsettings.ExpiryMinutes),
                claims: claims,
                signingCredentials:signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
