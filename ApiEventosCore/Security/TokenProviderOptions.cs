using Microsoft.IdentityModel.Tokens;
using System;

namespace ApiEventosCore.Security
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(120);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
