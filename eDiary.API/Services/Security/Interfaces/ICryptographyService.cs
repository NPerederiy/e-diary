namespace eDiary.API.Services.Security.Interfaces
{
    public interface ICryptographyService
    {
        string Decrypt(string data);
        string Encrypt(string data);
        string EncryptSHA256(string data);
        string EncryptPassword(string pass);
    }
}
