using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eDiary.API.Services.Security
{
    public static class AuthOptions
    {
        public const string ISSUER = "AuthServer165613299"; 
        public const string AUDIENCE = "diaryUser";
        public const int LIFETIME = 60; //1; // minutes
        private static readonly byte[] key; 
        private const int aesKeySize = 16;

        static AuthOptions()
        {
            using (var sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                key = sha256Hash.ComputeHash(
                    Encoding.UTF8.GetBytes(
                        "RPBSRE8Tsy4jct9BJ3yLnYHcDT9rFgKw7nrQrb2jmEcMyLkT6KWsavTD8rz2G98HRhf2yeVGzF7SrQGMbnBf3ekqRgEuqxGKzPhkBEc4jUnzF7ryUC3SBDTTSvn4Szva"
                    )
                );
            }
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(key);
        }
    }
}
