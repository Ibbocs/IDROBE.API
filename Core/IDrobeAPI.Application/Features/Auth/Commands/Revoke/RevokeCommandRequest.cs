using AutoMapper;
using FluentValidation;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Auth.Rules;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandRequest : IRequest<Unit>//unit piplene varimizdi deye orda nese donsun deyedi
    {
        public string Email { get; set; }
    }

    public class RevokeCommandValidator : AbstractValidator<RevokeCommandRequest>
    {
        public RevokeCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty();
        }
    }

    public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AuthRules authRules;

        public RevokeCommandHandler(UserManager<AppUser> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
            this.authRules = authRules;
        }

        //rft null eleyirem ki, logout olubsa rft ile giremmesin. jwt da id vermisem deye mecbur login olmalidi
        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await userManager.FindByEmailAsync(request.Email);
            await authRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
