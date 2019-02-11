namespace eDiary.API.Models.Entities
{
    public class Section
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)
        public int ProjectId { get; set; } // ProjectId

        // Reverse navigation

        /// <summary>
        /// Child Tasks where [Tasks].[SectionId] point to this entity (FK__Tasks__SectionId__5165187F)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Task> Tasks { get; set; } // Tasks.FK__Tasks__SectionId__5165187F

        // Foreign keys

        /// <summary>
        /// Parent Project pointed by [Sections].([ProjectId]) (FK__Sections__Projec__49C3F6B7)
        /// </summary>
        public virtual Project Project { get; set; } // FK__Sections__Projec__49C3F6B7

        public Section()
        {
            Tasks = new System.Collections.Generic.List<Task>();
        }
    }
}
