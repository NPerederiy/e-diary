namespace eDiary.API.Models.Entities
{
    public class UserSettings
    {
        public int Id { get; set; } // Id (Primary key)
        public int UserId { get; set; } // UserId
        public int? LanguageId { get; set; } // LanguageId
        public int RootFolderId { get; set; } // RootFolderId

        // Foreign keys

        /// <summary>
        /// Parent Folder pointed by [UserSettings].([RootFolderId]) (FK__UserSetti__RootF__74AE54BC)
        /// </summary>
        public virtual Folder Folder { get; set; } // FK__UserSetti__RootF__74AE54BC

        /// <summary>
        /// Parent Language pointed by [UserSettings].([LanguageId]) (FK__UserSetti__Langu__73BA3083)
        /// </summary>
        public virtual Language Language { get; set; } // FK__UserSetti__Langu__73BA3083

        /// <summary>
        /// Parent UserProfile pointed by [UserSettings].([UserId]) (FK__UserSetti__UserI__72C60C4A)
        /// </summary>
        public virtual UserProfile UserProfile { get; set; } // FK__UserSetti__UserI__72C60C4A
    }
}
