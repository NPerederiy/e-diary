namespace eDiary.API.Models.Entities
{
    public class Priority
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child Tasks where [Tasks].[PriorityId] point to this entity (FK__Tasks__PriorityI__4F7CD00D)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Task> Tasks { get; set; } // Tasks.FK__Tasks__PriorityI__4F7CD00D

        public Priority()
        {
            Tasks = new System.Collections.Generic.List<Task>();
        }
    }
}
