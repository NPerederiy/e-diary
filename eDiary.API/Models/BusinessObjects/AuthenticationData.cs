using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class AuthenticationData
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
