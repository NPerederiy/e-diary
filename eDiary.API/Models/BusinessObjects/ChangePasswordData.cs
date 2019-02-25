using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class ChangePasswordData
    {
        [Required(ErrorMessage = "Current password is required")]
        [JsonProperty("currentPassword")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        public ChangePasswordData(string currentPassword, string newPassword)
        {
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
