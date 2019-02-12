namespace eDiary.API.Services.Security.Interfaces
{
    public interface IIdentityService
    {
        string Authenticate(string login, string passHash);
        string Register(string firstName, string lastName, string passHash, string email);
    }
}
