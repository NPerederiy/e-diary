using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class TokenPayload
    {
        [JsonProperty("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")]
        public string Name { get; set; }
        [JsonProperty("iss")]
        public string Issuer { get; set; }
        [JsonProperty("aud")]
        public string Audience { get; set; }
        [JsonProperty("exp")]
        public string ExpirationTime { get; set; }

        public TokenPayload(string token)
        {
            var payload = GetPayload(token);
            Name = payload.Name;
            Issuer = payload.Issuer;
            Audience = payload.Audience;
            ExpirationTime = payload.ExpirationTime;
        }

        public static TokenPayload GetPayload(string token)
        {
            var json = System.Text.Encoding.ASCII.GetString(System.Convert.FromBase64String(token.Split('.')[1]));
            if (string.IsNullOrEmpty(json)) throw new System.Exception("Incorrect token format.");
            return JsonConvert.DeserializeObject<TokenPayload>(json);
        }
    }
}
