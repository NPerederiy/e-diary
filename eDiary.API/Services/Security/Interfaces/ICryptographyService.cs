namespace eDiary.API.Services.Security.Interfaces
{
    public interface ICryptographyService
    {
        string Encrypt(string pass);
        string Decrypt(string data);
    }
}
