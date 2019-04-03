using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class UserSettingsBO
    {
        [JsonProperty("settingsId")]
        public int SettingsId { get; set; }

        [Required(ErrorMessage = "UserProfileId is required")]
        [JsonProperty("userId")]
        public int UserProfileId { get; set; }

        [Required(ErrorMessage = "Language code is required")]
        [StringLength(2)]
        [JsonProperty("language")]
        public string LanguageCode { get; set; }

        [Required(ErrorMessage = "Root folder ID is required")]
        [JsonProperty("rootFolderId")]
        public int RootFolderId { get; set; }

        public UserSettingsBO(UserSettings settings)
        {
            SettingsId = settings.Id;
            UserProfileId = settings.UserId;
            LanguageCode = settings.Language.ShortCode;
            RootFolderId = settings.RootFolderId;
        }
    }
}
