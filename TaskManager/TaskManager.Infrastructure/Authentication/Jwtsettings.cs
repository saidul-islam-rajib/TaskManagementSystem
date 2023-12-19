﻿namespace TaskManager.Infrastructure.Authentication
{
    public class Jwtsettings
    {
        public const string SectionName = "JwtSettings";
        public string Secret { get; init; } = null!;
        public int ExpiryMinutes { get; init; }
        public string issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
