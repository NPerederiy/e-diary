using eDiary.API.Services.Security.Exceptions;
using eDiary.API.Services.Security.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace eDiary.API.Services.Security
{
    public sealed class CryptographyService : ICryptographyService
    {
        private readonly string localsalt = "h37sG3Gark-yfTQEy#fRX4uydN^E+gz?*TW7FpjN5vsyy^$md9&n2va&S$2HprUnSzjpYyepu6NAgW&FMb9AA@w?4CDE3-*7u^a_rBMe_NK*-vPX#rNsDL*_XF*YB^Q*tYYCJvdJSbjMs$8qM5-B=km?wAk*UrrStazmQCZXyWKA!V93q9qWCXYdD=sExdZXv5rRf84njg!wu6Uq8aZ_nJ+M3kt6vPzsNDFr-SuCnAv&@Zc_PNV-bN-zKWx+V-*CNZbGWp?$H2=f2^k9C*N4=TN*AJ^by-KWY!dYckFZBV^u?8mh6r^Q?+59ZNR8tm!W+htcZ=P+$JD+2ncVwhGt?%^CrGnJEMzmcYd_#!AV_EY$6xTLUB7J$5x84V$3xwDk3-eDdZvG-M!%#@gfxzxve2^wJNLRUbpZAPHujZ!ub$x9RggDU+Z_^a5Qd%m&4+adnunr9@z_TBRB3@hy7M8sDHwVXYVK&C%qS5-URqG&?!g48-Du#Bjuw=QjMcYv%?Cu";
        private readonly int controlNumber = 512;

        public string Decrypt(string data)
        {
            throw new System.NotImplementedException();
        }

        public string Encrypt(string pass)
        {
            ValidateParams(pass);
            var enc = UniteAndConvert(pass, localsalt);

            using (SHA512 sha256Hash = SHA512.Create())
            {
                enc = GetHash(sha256Hash, enc);
            }

            return enc;

            string UniteAndConvert(string str1, string str2)
            {
                var sBuilder = new StringBuilder();
                sBuilder.Append(str1[0]);
                for (var i = 1; i < str1.Length * 2; i++)
                {
                    sBuilder.Append(i % 2 == 0 ? str1[i / 2] : str2[i / 2]);
                }
                return sBuilder.ToString();
            }

            string GetHash(HashAlgorithm hashAlgorithm, string input)
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

        private void ValidateParams(string pass)
        {
            if (pass.Length != controlNumber) throw new SecurityException("Incorrect password length");
            if (localsalt.Length != controlNumber) throw new SecurityException("Incorrect salt length");
        }
    }
}
