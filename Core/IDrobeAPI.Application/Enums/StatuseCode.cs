using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDrobeAPI.Application.Enums
{
    public enum StatuseCode
    {
        Success,
        RecordNotFound,
        InvalidCreateHash,
        ExpiredCreateHash,
        ExpiredModifyHash,
        UnableToCreateRecord,
        UnableToUpdateRecord,
        UnableToSoftDeleteRecord,
        UnableToHardDeleteRecord,
        UserAlreadyExists,
        EmailCannotBeBlank,
        PasswordCannotBeBlank,
        PasswordResetHashExpired,
        AccountNotActivated,
        InvalidEmail,
        InvalidPassword,
        InvalidPageAction
    }
}
