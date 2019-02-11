namespace eDiary.API.Models.Entities
{
    public class Difficulty
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child Tasks where [Tasks].[DifficultyId] point to this entity (FK__Tasks__Difficult__5070F446)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Task> Tasks { get; set; } // Tasks.FK__Tasks__Difficult__5070F446

        public Difficulty()
        {
            Tasks = new System.Collections.Generic.List<Task>();
        }
    }
}
