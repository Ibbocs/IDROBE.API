using FluentValidation;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Auth.Rules;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using IDrobeAPI.Application.Interfaces.ITokens;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Auth.Commands.RefreshTokenLogin
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }

    public class RefreshTokenCommandHandler : BaseHandler, IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<AppUser> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommandHandler(ICustomMapper mapper, AuthRules authRules, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);//bu jwt dogrulugunu yoxlayib bize claimlere el catan eleyir
            string email = principal.FindFirstValue(ClaimTypes.Email);

            AppUser? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

            await authRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };
        }

        public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommandRequest>
        {
            public RefreshTokenCommandValidator()
            {
                RuleFor(x => x.AccessToken).NotEmpty();

                RuleFor(x => x.RefreshToken).NotEmpty();
            }
        }
    }
}
