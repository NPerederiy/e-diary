namespace eDiary.API.Models.Entities
{
    public class TagReference
    {
        public int Id { get; set; } // Id (Primary key)
        public int TagId { get; set; } // TagId
        public int? TaskId { get; set; } // TaskId
        public int? NoteId { get; set; } // NoteId

        // Foreign keys

        /// <summary>
        /// Parent Note pointed by [TagReferences].([NoteId]) (FK__TagRefere__NoteI__6754599E)
        /// </summary>
        public virtual Note Note { get; set; } // FK__TagRefere__NoteI__6754599E

        /// <summary>
        /// Parent Tag pointed by [TagReferences].([TagId]) (FK__TagRefere__TagId__656C112C)
        /// </summary>
        public virtual Tag Tag { get; set; } // FK__TagRefere__TagId__656C112C

        /// <summary>
        /// Parent Task pointed by [TagReferences].([TaskId]) (FK__TagRefere__TaskI__66603565)
        /// </summary>
        public virtual Task Task { get; set; } // FK__TagRefere__TaskI__66603565
    }
}
