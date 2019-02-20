using eDiary.API.Models.EF;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace eDiary.API.Models.Entities
{
    public class Task
    {
        public int Id { get; set; } // Id (Primary key)
        public string Header { get; set; } // Header (length: 2147483647)
        public string Description { get; set; } // Description (length: 2147483647)
        public string Deadline { get; set; } // Deadline (length: 2147483647)
        public int? Progress { get; set; } // Progress
        public string CreatedAt { get; set; } // CreatedAt (length: 2147483647)
        public string UpdatedAt { get; set; } // UpdatedAt (length: 2147483647)
        public int StatusId { get; set; } // StatusId
        public int CardStatusId { get; set; } // CardStatusId
        public int PriorityId { get; set; } // PriorityId
        public int DifficultyId { get; set; } // DifficultyId
        public int? SectionId { get; set; } // SectionId

        // Reverse navigation

        /// <summary>
        /// Child AttachedFiles where [AttachedFiles].[TaskId] point to this entity (FK__AttachedF__TaskI__6A30C649)
        /// </summary>
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; } // AttachedFiles.FK__AttachedF__TaskI__6A30C649
        /// <summary>
        /// Child AttachedLinks where [AttachedLinks].[TaskId] point to this entity (FK__AttachedL__TaskI__619B8048)
        /// </summary>
        public virtual ICollection<AttachedLink> AttachedLinks { get; set; } // AttachedLinks.FK__AttachedL__TaskI__619B8048
        /// <summary>
        /// Child Comments where [Comments].[TaskId] point to this entity (FK__Comments__TaskId__5812160E)
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; } // Comments.FK__Comments__TaskId__5812160E
        /// <summary>
        /// Child Subtasks where [Subtasks].[TaskId] point to this entity (FK__Subtasks__TaskId__5535A963)
        /// </summary>
        public virtual ICollection<Subtask> Subtasks { get; set; } // Subtasks.FK__Subtasks__TaskId__5535A963
        /// <summary>
        /// Child TagReferences where [TagReferences].[TaskId] point to this entity (FK__TagRefere__TaskI__66603565)
        /// </summary>
        public virtual ICollection<TagReference> TagReferences { get; set; } // TagReferences.FK__TagRefere__TaskI__66603565

        // Foreign keys

        /// <summary>
        /// Parent CardStatus pointed by [Tasks].([CardStatusId]) (FK__Tasks__CardStatu__4E88ABD4)
        /// </summary>
        public virtual CardStatus CardStatus { get; set; } // FK__Tasks__CardStatu__4E88ABD4

        /// <summary>
        /// Parent Difficulty pointed by [Tasks].([DifficultyId]) (FK__Tasks__Difficult__5070F446)
        /// </summary>
        public virtual Difficulty Difficulty { get; set; } // FK__Tasks__Difficult__5070F446

        /// <summary>
        /// Parent Priority pointed by [Tasks].([PriorityId]) (FK__Tasks__PriorityI__4F7CD00D)
        /// </summary>
        public virtual Priority Priority { get; set; } // FK__Tasks__PriorityI__4F7CD00D

        /// <summary>
        /// Parent Section pointed by [Tasks].([SectionId]) (FK__Tasks__SectionId__5165187F)
        /// </summary>
        public virtual Section Section { get; set; } // FK__Tasks__SectionId__5165187F

        /// <summary>
        /// Parent Status pointed by [Tasks].([StatusId]) (FK__Tasks__StatusId__4D94879B)
        /// </summary>
        public virtual Status Status { get; set; } // FK__Tasks__StatusId__4D94879B

        public Task()
        {
            Progress = 0;
            AttachedFiles = new List<AttachedFile>();
            AttachedLinks = new List<AttachedLink>();
            Comments = new List<Comment>();
            Subtasks = new List<Subtask>();
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
