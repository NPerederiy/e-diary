namespace eDiary.API.Models.Entities
{
    public class Language
    {
        public int Id { get; set; } // Id (Primary key)
        public string ShortCode { get; set; } // ShortCode (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child UserSettings where [UserSettings].[LanguageId] point to this entity (FK__UserSetti__Langu__73BA3083)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<UserSetting> UserSettings { get; set; } // UserSettings.FK__UserSetti__Langu__73BA3083

        public Language()
        {
            UserSettings = new System.Collections.Generic.List<UserSetting>();
        }
    }
}
