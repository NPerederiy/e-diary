namespace eDiary.API.Services.Security.Interfaces
{
    public interface ICryptographyService
    {
        IOperationResult Decrypt(string data);
        IOperationResult Encrypt(string data);
        IOperationResult EncryptSHA256(string data);
        IOperationResult EncryptPassword(string pass);
    }
}
