using System.ComponentModel.DataAnnotations.Schema;

namespace eDiary.API.Models.Entities
{
    public class ProjectCategory
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        [ForeignKey("UserProfile")]
        public int UserId { get; set; } // UserId

        // Reverse navigation

        /// <summary>
        /// Child Projects where [Projects].[CategoryId] point to this entity (FK__Projects__Catego__45F365D3)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Projects.FK__Projects__Catego__45F365D3

        // Foreign keys

        /// <summary>
        /// Parent UserProfile pointed by [ProjectCategories].([UserId]) (FK__ProjectCa__UserI__4316F928)
        /// </summary>
        public virtual UserProfile UserProfile { get; set; } // FK__ProjectCa__UserI__4316F928

        public ProjectCategory()
        {
            Projects = new System.Collections.Generic.List<Project>();
        }
    }
}
