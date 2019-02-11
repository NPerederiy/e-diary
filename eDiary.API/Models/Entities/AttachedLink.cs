namespace eDiary.API.Models.Entities
{
    public class AttachedLink
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)
        public string Link { get; set; } // Link (length: 2147483647)
        public int? TaskId { get; set; } // TaskId
        public int? NoteId { get; set; } // NoteId

        // Foreign keys

        /// <summary>
        /// Parent Note pointed by [AttachedLinks].([NoteId]) (FK__AttachedL__NoteI__628FA481)
        /// </summary>
        public virtual Note Note { get; set; } // FK__AttachedL__NoteI__628FA481

        /// <summary>
        /// Parent Task pointed by [AttachedLinks].([TaskId]) (FK__AttachedL__TaskI__619B8048)
        /// </summary>
        public virtual Task Task { get; set; } // FK__AttachedL__TaskI__619B8048
    }
}
