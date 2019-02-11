namespace eDiary.API.Models.Entities
{
    public class Subtask
    {
        public int Id { get; set; } // Id (Primary key)
        public string Text { get; set; } // Text (length: 2147483647)
        public int? IsCompleted { get; set; } // IsCompleted
        public int? TaskId { get; set; } // TaskId

        // Foreign keys

        /// <summary>
        /// Parent Task pointed by [Subtasks].([TaskId]) (FK__Subtasks__TaskId__5535A963)
        /// </summary>
        public virtual Task Task { get; set; } // FK__Subtasks__TaskId__5535A963

        public Subtask()
        {
            IsCompleted = 0;
        }
    }
}
