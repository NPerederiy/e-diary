using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "First name is required")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [JsonProperty("email")]
        public string Email { get; set; }
        
        //[JsonProperty("username")]
        //public string Username { get; set; }

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
