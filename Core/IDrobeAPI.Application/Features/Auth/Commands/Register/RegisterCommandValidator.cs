using FluentValidation;

namespace IDrobeAPI.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(2)
                .WithName("İsim Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(60)
                .EmailAddress()
                .MinimumLength(8)
                .WithName("E-posta Adresi");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithName("Parola");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .Equal(x => x.Password)
                .WithName("Parola Tekrarı");
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
