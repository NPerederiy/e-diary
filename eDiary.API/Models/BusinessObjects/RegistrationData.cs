using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class RegistrationData
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        //[JsonProperty("username")]
        //public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }

        //public RegistrationData(string firstName, string lastName, string username, string password, string email)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Username = username;
        //    Password = password;
        //    Email = email;
        //}

        public RegistrationData(string firstName, string lastName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }
    }
}
