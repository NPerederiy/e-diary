namespace eDiary.API.Models.Entities
{
    public class AttachedFile
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)
        public string Link { get; set; } // Link (length: 2147483647)
        public int? TaskId { get; set; } // TaskId
        public int? NoteId { get; set; } // NoteId

        // Foreign keys

        /// <summary>
        /// Parent Note pointed by [AttachedFiles].([NoteId]) (FK__AttachedF__NoteI__6B24EA82)
        /// </summary>
        public virtual Note Note { get; set; } // FK__AttachedF__NoteI__6B24EA82

        /// <summary>
        /// Parent Task pointed by [AttachedFiles].([TaskId]) (FK__AttachedF__TaskI__6A30C649)
        /// </summary>
        public virtual Task Task { get; set; } // FK__AttachedF__TaskI__6A30C649
    }
}
