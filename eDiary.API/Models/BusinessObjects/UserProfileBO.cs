using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class UserProfileBO
    {
        [JsonProperty("profileId")]
        public int ProfileId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [JsonProperty("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "The email format is not valid")]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("profileImage")]
        public string ProfileImage { get; set; }

        public UserProfileBO(UserProfile entity)
        {
            ProfileId = entity.Id;
            Username = entity.AppUsers.First().Username;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Email = entity.Email;
            ProfileImage = null;    // TODO: implement this
        }
    }
}
