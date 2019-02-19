using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class ChangePasswordData
    {
        [JsonProperty("currentPassword")]
        public string CurrentPassword { get; set; }
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        public ChangePasswordData(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
