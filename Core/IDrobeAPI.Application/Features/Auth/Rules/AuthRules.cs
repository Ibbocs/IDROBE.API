using IDrobeAPI.Application.BaseObjects;
using IDrobeAPI.Application.Features.Auth.Exceptions;
using IDrobeAPI.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(AppUser? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(AppUser? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public Task EmailAddressShouldBeValid(AppUser? user)
        {
            if (user is null) throw new EmailAddressShouldBeValidException();
            return Task.CompletedTask;
        }
    }
}
