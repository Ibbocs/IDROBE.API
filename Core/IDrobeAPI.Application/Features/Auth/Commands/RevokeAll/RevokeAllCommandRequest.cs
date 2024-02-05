using AutoMapper;
using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Auth.Commands.RevokeAll
{
    public class RevokeAllCommandRequest : IRequest<Unit>
    {
    }

    public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
    {
        private readonly UserManager<AppUser> userManager;
        public RevokeAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            List<AppUser> users = await userManager.Users.ToListAsync(cancellationToken);

            foreach (AppUser user in users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }

            return Unit.Value;
        }
    }
}
