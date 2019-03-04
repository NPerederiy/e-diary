using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Validation;
using System.Security.Cryptography;
using System.Text;

namespace eDiary.API.Services.Security
{
    internal sealed class CryptographyService : ICryptographyService
    {
        private readonly string localsalt = "RPBSRE8Tsy4jct9BJ3yLnYHcDT9rFgKw7nrQrb2jmEcMyLkT6KWsavTD8rz2G98HRhf2yeVGzF7SrQGMbnBf3ekqRgEuqxGKzPhkBEc4jUnzF7ryUC3SBDTTSvn4Szva";
        private readonly int controlNumber = 128;
        
        public string Decrypt(string data)
        {
            Validate.NotNull(data, nameof(data));
            throw new System.NotImplementedException();
        }
        
        public string Encrypt(string data)
        {
            Validate.NotNull(data, nameof(data));
            throw new System.NotImplementedException();
        }
        
        public string EncryptSHA256(string data)
        {
            Validate.NotNull(data, nameof(data));
            var sha256Hash = SHA256.Create();
            return GetHash(sha256Hash, data);
        }
        
        public string EncryptPassword(string pass)
        {
            Validate.NotNull(pass, "Password");
            Validate.RequiredLength(pass, controlNumber, "Password");
            Validate.RequiredLength(localsalt, controlNumber, "Salt");

            var enc = Union(pass, localsalt);

            using (var sha256Hash = SHA512.Create())
            {
                enc = GetHash(sha256Hash, enc);
            }

            return enc;

            string Union(string str1, string str2)
            {
                var sBuilder = new StringBuilder();
                sBuilder.Append(str1[0]);
                for (var i = 1; i < str1.Length * 2; i++)
                {
                    sBuilder.Append(i % 2 == 0 ? str1[i / 2] : str2[i / 2]);
                }
                return sBuilder.ToString();
            }
        }

        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
