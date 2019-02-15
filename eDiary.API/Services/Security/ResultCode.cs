namespace eDiary.API.Services.Security
{
    public enum ResultCode
    {
        Succeeded,
        UserNotFound,
        UsernameAlreadyExists,
        EmailAlreadyExists,
        PasswordsNotMatch,
        IncorrectUsername,
        IncorrectPassword,
        IncorrectFirstName,
        IncorrectLastName,
        IncorrectEmail,
        EncryptionError
    }
}
