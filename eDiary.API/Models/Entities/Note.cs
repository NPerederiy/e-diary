using eDiary.API.Models.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eDiary.API.Models.Entities
{
    public class Note
    {
        public int Id { get; set; } // Id (Primary key)
        public string Header { get; set; } // Header (length: 2147483647)
        public string Description { get; set; } // Description (length: 2147483647)
        public int StatusId { get; set; } // StatusId
        public int FolderId { get; set; } // FolderId
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }


        // Reverse navigation

        /// <summary>
        /// Child AttachedFiles where [AttachedFiles].[NoteId] point to this entity (FK__AttachedF__NoteI__6B24EA82)
        /// </summary>
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; } // AttachedFiles.FK__AttachedF__NoteI__6B24EA82
        /// <summary>
        /// Child AttachedLinks where [AttachedLinks].[NoteId] point to this entity (FK__AttachedL__NoteI__628FA481)
        /// </summary>
        public virtual ICollection<AttachedLink> AttachedLinks { get; set; } // AttachedLinks.FK__AttachedL__NoteI__628FA481
        /// <summary>
        /// Child TagReferences where [TagReferences].[NoteId] point to this entity (FK__TagRefere__NoteI__6754599E)
        /// </summary>
        public virtual ICollection<TagReference> TagReferences { get; set; } // TagReferences.FK__TagRefere__NoteI__6754599E

        // Foreign keys

        /// <summary>
        /// Parent Folder pointed by [Notes].([FolderId]) (FK__Notes__FolderId__5EBF139D)
        /// </summary>
        public virtual Folder Folder { get; set; } // FK__Notes__FolderId__5EBF139D

        /// <summary>
        /// Parent Status pointed by [Notes].([StatusId]) (FK__Notes__StatusId__5DCAEF64)
        /// </summary>
        public virtual Status Status { get; set; } // FK__Notes__StatusId__5DCAEF64

        public Note()
        {
            AttachedFiles = new List<AttachedFile>();
            AttachedLinks = new List<AttachedLink>();
            TagReferences = new List<TagReference>();
        }

        public Tag[] GetTags()
        {
            var tags = new List<Tag>();
            using (DbContext context = new BasicDiaryDbContext())
            {
                foreach (var reference in TagReferences)
                {
                    tags.Add(context.Set<Tag>().Where(x => x.Id == reference.TagId).FirstOrDefault());
                }
            }
            return tags.ToArray();
        }
    }
}
