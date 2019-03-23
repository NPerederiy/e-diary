using eDiary.API.Services.Security.Interfaces;
using eDiary.API.Services.Validation;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eDiary.API.Services.Security
{
    internal sealed class CryptographyService : ICryptographyService
    {
        private readonly string localsalt = "RPBSRE8Tsy4jct9BJ3yLnYHcDT9rFgKw7nrQrb2jmEcMyLkT6KWsavTD8rz2G98HRhf2yeVGzF7SrQGMbnBf3ekqRgEuqxGKzPhkBEc4jUnzF7ryUC3SBDTTSvn4Szva";
        private readonly int controlNumber = 128;
        private readonly int aesKeySize = 16;
        private readonly int aesBlockSize = 16;
        private readonly int usernameLength = 128;
        
        public string GenerateRefreshToken()
        {
            var refreshToken = new byte[64];

            using (var csp = new RNGCryptoServiceProvider())
            {
                csp.GetBytes(refreshToken);
            }

            return Convert.ToBase64String(refreshToken, Base64FormattingOptions.None);
        }

        public string EncryptToken(string token, string pin)
        {
            var decodeToken = DecodeToken(token);

            //var iv = GenerateRandomBytes(aesBlockSize);
            var salt = GenerateRandomBytes(aesKeySize);
            byte[] key = null;

            using (var rfc = new Rfc2898DeriveBytes(pin, salt))
            {
                key = rfc.GetBytes(aesKeySize);
            }

            return EncodeBase64(EncryptAES(token, key));
        }

        public byte[] DecodeToken(string token)
        {
            return Convert.FromBase64String(token);
        }

        public byte[] EncryptAES(string plainText, byte[] key)
        {
            Validate.NotNull(plainText, nameof(plainText));
            Validate.NotNull(key, nameof(key));

            byte[] encrypted;
            byte[] IV;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                aesAlg.GenerateIV();
                IV = aesAlg.IV;

                aesAlg.Mode = CipherMode.CBC;

                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption. 
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            // Return the encrypted bytes from the memory stream. 
            return combinedIvCt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherTextCombined">Base64 encoded string</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DecryptAES(string cipherTextCombined, byte[] key)
        {
            return DecryptAES(Convert.FromBase64String(cipherTextCombined), key);
        }

        public string DecryptAES(byte[] cipherTextCombined, byte[] key)
        {
            Validate.NotNull(cipherTextCombined, nameof(cipherTextCombined));
            Validate.NotNull(key, nameof(key));

            // Declare the string used to hold 
            // the decrypted text. 
            string plaintext = null;

            // Create an Aes object 
            // with the specified key and IV. 
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                byte[] IV = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[cipherTextCombined.Length - IV.Length];

                Array.Copy(cipherTextCombined, IV, IV.Length);
                Array.Copy(cipherTextCombined, IV.Length, cipherText, 0, cipherText.Length);

                aesAlg.IV = IV;

                aesAlg.Mode = CipherMode.CBC;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption. 
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return plaintext;
        }

        public string EncryptSHA256(string plainText)
        {
            Validate.NotNull(plainText, nameof(plainText));
            var sha256Hash = SHA256.Create();
            return GetHash(sha256Hash, plainText);
        }
        
        public string EncryptPassword(string pass)
        {
            Validate.NotNull(pass, "Password");
            Validate.RequiredLength(pass, controlNumber, "Password");
            Validate.RequiredLength(localsalt, controlNumber, "Salt");

            var enc = Union(pass, localsalt);

            using (var sha512Hash = SHA512.Create())
            {
                enc = GetHash(sha512Hash, enc);
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

        public string GenerateUsername()
        {
            return EncodeBase64(GenerateRandomBytes(usernameLength));
        }

        public string EncodeBase64(string plainText)
        {
            return EncodeBase64(Encoding.UTF8.GetBytes(plainText));
        }

        public string EncodeBase64(byte[] plainText)
        {
            return Convert.ToBase64String(plainText);
        }

        public string DecodeBase64(string encodedString)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encodedString));
        }

        private byte[] GenerateRandomBytes(int size)
        {
            var rnd = new byte[size];
            using (var csp = new RNGCryptoServiceProvider())
            {
                csp.GetBytes(rnd);
            }
            return rnd;
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
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
