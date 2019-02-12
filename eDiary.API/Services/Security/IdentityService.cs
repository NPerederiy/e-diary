using eDiary.API.Services.Security.Exceptions;
using eDiary.API.Services.Security.Interfaces;

namespace eDiary.API.Services.Security
{
    public class IdentityService : IIdentityService
    {
        private readonly ICryptographyService cs;

        public IdentityService(ICryptographyService cs)
        {
            this.cs = cs;
        }

        public string Authenticate(string login, string passHash)
        {
            if (login == null) throw new SecurityException("Login can not be NULL");
            if (passHash == null) throw new SecurityException("Password string can not be NULL");

            var enc = cs.Encrypt(passHash);


            throw new System.NotImplementedException();
        }

        public string Register(string firstName, string lastName, string passHash, string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
