using IDrobeAPI.Application.Interfaces.ITokens;
using IDrobeAPI.Domain.Identity;
using IDrobeAPI.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Infrastructure.Implementation.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly TokenSettings _tokenSettings;

        public TokenService(IOptions<TokenSettings> options, UserManager<AppUser> userManager)
        {
            _tokenSettings = options.Value;
            this.userManager = userManager;
        }

        public async Task<JwtSecurityToken> CreateToken(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jwt idsi, logout olmus
                //new Claim(JwtRegisteredClaimNames.Jti, user.RefreshToken !=null ? user.RefreshToken : " "), //logout olmus userin elinde aktiv jwt olsa bele hemin jwt gecersiz olsun
                //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                //ClaimTypes.IsPersistent - beni hatirla bu claim ile edilir
               // new Claim("revoked", user.IsRevoked ? "true" : "false" )//logout icin bele bir claim daha mentiqlidi, logout ve ya passwchange edende get bunu true cek ve IsTokenValid kimi bir method olsun, true olanda bilek jwt gecersizdi. Login olanda ise bunu false cek. database userde bele bir stutun olmalidi amma
            };

            //public bool IsTokenValid(string token)
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            //    if (jwtToken != null)
            //    {
            //        var isRevokedClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "revoked")?.Value;

            //        // "revoked" özelliği "true" ise token geçersizdir.
            //        return isRevokedClaim != "true";
            //    }

            //    // Geçerli bir JWT değilse kabul etme
            //    return false;
            //}

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_tokenSettings.TokenValidityInMunitues),
                notBefore: DateTime.UtcNow, //islemeye baslayacagi vaxt
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            await userManager.AddClaimsAsync(user, claims);//claimsleri jwt vererken database elave edirem
            //tokenHandler.WriteToken(token);

            return token;

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();//64bitlik random rft yaradiram
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)//rft ile registerde isledecem bu  methodu, jwt olan userin claimslerin almaq ucun
        {
            TokenValidationParameters tokenValidationParamaters = new()
            {
                //todo buralari helelik baglamisam
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Secret)),
                ValidateLifetime = false
            };

            JwtSecurityTokenHandler tokenHandler = new();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParamaters, out SecurityToken securityToken);
            
            //Validasyadan token kecmese xeta atiram
            if (securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Dont Find Any Token");

            return principal;

        }
    }
}
