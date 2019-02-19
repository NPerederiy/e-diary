using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class UserProfileBO
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("profileImage")]
        public string ProfileImage { get; set; }

        public UserProfileBO(UserProfile entity)
        {
            UserId = entity.Id;
            FirstName = entity.FirstName;
            LastName = entity.LastName;
            Email = entity.Email;
            ProfileImage = null;    // TODO: implement this
        }
    }
}
