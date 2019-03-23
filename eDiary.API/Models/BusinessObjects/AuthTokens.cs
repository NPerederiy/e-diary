using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class AuthTokens
    {
        [JsonProperty("access")]
        public string AccessToken { get; set; }
        [JsonProperty("refresh")]
        public string RefreshToken { get; set; }

        public AuthTokens(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
