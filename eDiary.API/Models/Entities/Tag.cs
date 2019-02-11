namespace eDiary.API.Models.Entities
{
    public class Tag
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 2147483647)

        // Reverse navigation

        /// <summary>
        /// Child TagReferences where [TagReferences].[TagId] point to this entity (FK__TagRefere__TagId__656C112C)
        /// </summary>
        public virtual System.Collections.Generic.ICollection<TagReference> TagReferences { get; set; } // TagReferences.FK__TagRefere__TagId__656C112C

        public Tag()
        {
            TagReferences = new System.Collections.Generic.List<TagReference>();
        }
    }
}
