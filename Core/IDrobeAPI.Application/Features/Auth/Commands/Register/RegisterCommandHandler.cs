using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Auth.Rules;
using IDrobeAPI.Application.Interfaces.IAutoMapper;
using IDrobeAPI.Application.Interfaces.IUnitOfWorks;
using IDrobeAPI.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace IDrobeAPI.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ICustomMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            AppUser user = mapper.Map<AppUser, RegisterCommandRequest>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                //todo burda event falan ile role oz creat calisdirmak lazim
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new AppRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                    });

                await userManager.AddToRoleAsync(user, "user");
            }

            return Unit.Value;
        }
    }

    ////bir commandan bir baskasin tetiklmek- sondaki daha iyi
    //public class UserRegisteredEvent : INotification
    //{
    //    public AppUser User { get; }

    //    public UserRegisteredEvent(AppUser user)
    //    {
    //        User = user;
    //    }
    //}

    //public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    //{
    //    await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

    //    AppUser user = mapper.Map<AppUser, RegisterCommandRequest>(request);
    //    user.UserName = request.Email;
    //    user.SecurityStamp = Guid.NewGuid().ToString();

    //    IdentityResult result = await userManager.CreateAsync(user, request.Password);
    //    if (result.Succeeded)
    //    {


    //        if (!await roleManager.RoleExistsAsync("user"))
    //            // Olayı tetikle
    //            await mediator.Publish(new UserRegisteredEvent(user), cancellationToken);

    //        await userManager.AddToRoleAsync(user, "user");
    //    }

    //    return Unit.Value;
    //}

    //public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
    //{
    //    public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    //    {
    //        // Yeni kullanıcı kaydı yapıldı, burada gerekli işlemleri yapabilirsiniz.
    //        // Örneğin, kullanıcıya hoş geldin e-postası gönderme, başka bir işlem tetikleme, vb.
    //        await roleManager.CreateAsync(new AppRole
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            Name = "user",
    //            NormalizedName = "USER",
    //            ConcurrencyStamp = Guid.NewGuid().ToString(),
    //        });

    //        return Task.CompletedTask;
    //    }
    //}

    //public class UserRegisteredEvent : INotification
    //{
    //    public AppUser User { get; }

    //    public UserRegisteredEvent(AppUser user)
    //    {
    //        User = user;
    //    }
    //}

    //public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
    //{
    //    private readonly IMediator _mediator;

    //    public UserRegisteredEventHandler(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    //    {
    //        // Yeni kullanıcı kaydı yapıldı, burada gerekli işlemleri yapabilirsiniz.
    //        // Örneğin, kullanıcıya hoş geldin e-postası gönderme, başka bir işlem tetikleme, vb.

    //        // CreateRoleCommand tetikleme
    //        await _mediator.Send(new CreateRoleCommandRequest { UserId = notification.User.Id });

    //        // Diğer işlemleri gerçekleştirme
    //    }
    //}


}
