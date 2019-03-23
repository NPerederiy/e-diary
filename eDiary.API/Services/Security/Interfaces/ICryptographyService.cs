namespace eDiary.API.Services.Security.Interfaces
{
    public interface ICryptographyService
    {
        string EncryptSHA256(string plainText);
        string EncryptToken(string token, string pin);
        byte[] EncryptAES(string plainText, byte[] key);
        string DecryptAES(string cipherTextCombined, byte[] key);
        string DecryptAES(byte[] cipherTextCombined, byte[] key);
        string EncryptPassword(string pass);
        string EncodeBase64(string plainText);
        string EncodeBase64(byte[] plainText);
        string DecodeBase64(string encodedString);
        string GenerateUsername();
        string GenerateRefreshToken();
    }
}
