using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class AuthenticationData
    {
        [Required(ErrorMessage = "Username is required")]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [JsonProperty("password")]
        public string Password { get; set; }

        public AuthenticationData(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
