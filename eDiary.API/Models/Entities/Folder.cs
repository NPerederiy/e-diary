namespace eDiary.API.Models.Entities
{
    public class Folder
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)
        public int? ParentFolderId { get; set; } // ParentFolderId

        // Reverse navigation

        /// <summary>
        /// Child Folders where [Folders].[ParentFolderId] point to this entity (FK__Folders__ParentF__5AEE82B9)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Folder> Folders { get; set; } // Folders.FK__Folders__ParentF__5AEE82B9
        /// <summary>
        /// Child Notes where [Notes].[FolderId] point to this entity (FK__Notes__FolderId__5EBF139D)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Note> Notes { get; set; } // Notes.FK__Notes__FolderId__5EBF139D
        /// <summary>
        /// Child UserSettings where [UserSettings].[RootFolderId] point to this entity (FK__UserSetti__RootF__74AE54BC)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<UserSetting> UserSettings { get; set; } // UserSettings.FK__UserSetti__RootF__74AE54BC

        // Foreign keys

        /// <summary>
        /// Parent Folder pointed by [Folders].([ParentFolderId]) (FK__Folders__ParentF__5AEE82B9)
        /// </summary>
        public virtual Folder ParentFolder { get; set; } // FK__Folders__ParentF__5AEE82B9

        public Folder()
        {
            Folders = new System.Collections.Generic.List<Folder>();
            Notes = new System.Collections.Generic.List<Note>();
            UserSettings = new System.Collections.Generic.List<UserSetting>();
        }
    }
}
