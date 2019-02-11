namespace eDiary.API.Models.Entities
{
    public class Project
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)
        public int? CategoryId { get; set; } // CategoryId
        public int UserId { get; set; } // UserId

        // Reverse navigation

        /// <summary>
        /// Child Sections where [Sections].[ProjectId] point to this entity (FK__Sections__Projec__49C3F6B7)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<Section> Sections { get; set; } // Sections.FK__Sections__Projec__49C3F6B7

        // Foreign keys

        /// <summary>
        /// Parent ProjectCategory pointed by [Projects].([CategoryId]) (FK__Projects__Catego__45F365D3)
        /// </summary>
        public virtual ProjectCategory ProjectCategory { get; set; } // FK__Projects__Catego__45F365D3

        /// <summary>
        /// Parent UserProfile pointed by [Projects].([UserId]) (FK__Projects__UserId__46E78A0C)
        /// </summary>
        public virtual UserProfile UserProfile { get; set; } // FK__Projects__UserId__46E78A0C

        public Project()
        {
            Sections = new System.Collections.Generic.List<Section>();
        }
    }
}
