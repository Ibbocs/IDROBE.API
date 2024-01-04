using IDrobeAPI.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Interfaces.ITokens
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateToken(AppUser user, IList<string> roles);
        string GenerateRefreshToken();
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}
