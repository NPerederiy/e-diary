namespace eDiary.API.Models.Entities
{
    public class Comment
    {
        public int Id { get; set; } // Id (Primary key)
        public string Text { get; set; } // Text (length: 2147483647)
        public int TaskId { get; set; } // TaskId

        // Foreign keys

        /// <summary>
        /// Parent Task pointed by [Comments].([TaskId]) (FK__Comments__TaskId__5812160E)
        /// </summary>
        public virtual Task Task { get; set; } // FK__Comments__TaskId__5812160E
    }
}
