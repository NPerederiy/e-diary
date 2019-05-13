using System.ComponentModel.DataAnnotations.Schema;

namespace eDiary.API.Models.Entities
{
    [Table("dbo.CardStatuses")]
    public class CardStatus
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child Tasks where [Tasks].[CardStatusId] point to this entity (FK__Tasks__CardStatu__4E88ABD4)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Task> Tasks { get; set; } // Tasks.FK__Tasks__CardStatu__4E88ABD4

        public CardStatus()
        {
            Tasks = new System.Collections.Generic.List<Task>();
        }
    }
}
