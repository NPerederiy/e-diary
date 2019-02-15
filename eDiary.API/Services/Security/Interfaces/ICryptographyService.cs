namespace eDiary.API.Services.Security.Interfaces
{
    public interface ICryptographyService
    {
        IOperationResult Decrypt(string data);
        IOperationResult Encrypt(string data);
        IOperationResult EncryptPassword(string pass);
    }
}
