using TaskManager.Domain.Entities;

namespace TaskManager.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
