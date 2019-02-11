namespace eDiary.API.Models.Entities
{
    public class Status
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child Notes where [Notes].[StatusId] point to this entity (FK__Notes__StatusId__5DCAEF64)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Note> Notes { get; set; } // Notes.FK__Notes__StatusId__5DCAEF64
        /// <summary>
        /// Child Tasks where [Tasks].[StatusId] point to this entity (FK__Tasks__StatusId__4D94879B)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Task> Tasks { get; set; } // Tasks.FK__Tasks__StatusId__4D94879B

        public Status()
        {
            Notes = new System.Collections.Generic.List<Note>();
            Tasks = new System.Collections.Generic.List<Task>();
        }
    }
}
