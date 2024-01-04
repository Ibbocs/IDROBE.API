using IDrobeAPI.Application.BaseObjects;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") { }
    }

    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
    }

    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı adı veya şifre yanlıştır.") { }

    }

    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın.") { }
    }

    //todo Exceptionlari bele umumi hala getirmek olar
    public class AuthenticationException : BaseException
    {
        private AuthenticationException(string message) : base(message) { }

        public static AuthenticationException UserAlreadyExists() =>
            new AuthenticationException("Böyle bir kullanıcı zaten var!");

        public static AuthenticationException EmailAddressNotExists() =>
            new AuthenticationException("Böyle bir email adresi bulunmamaktadır.");

        public static AuthenticationException InvalidUsernameOrPassword() =>
            new AuthenticationException("Kullanıcı adı veya şifre yanlıştır.");

        public static AuthenticationException RefreshTokenExpired() =>
            new AuthenticationException("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın.");
    }

    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int productId)
            : base($"Ürün bulunamadı. ID: {productId}")
        {
        }
    }

    public class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(int brandId)
            : base($"Marka bulunamadı. ID: {brandId}")
        {
        }
    }

    //ve ya
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {
        }
    }

    public class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(string entityName, int entityId)
            : base($"{entityName} bulunamadı. ID: {entityId}")
        {
        }
    }

    public class EntityAlreadyExistsException : BusinessException
    {
        public EntityAlreadyExistsException(string entityName)
            : base($"{entityName} zaten var.")
        {
        }
    }

    public class InvalidEntityStateException : BusinessException
    {
        public InvalidEntityStateException(string entityName, string state)
            : base($"{entityName} geçersiz durumda: {state}")
        {
        }
    }

    // CRUD işlemleri için diğer özel hata sınıfları...

}


