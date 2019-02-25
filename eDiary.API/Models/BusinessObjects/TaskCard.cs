using eDiary.API.Models.Entities;
using eDiary.API.Util;
using Newtonsoft.Json;
using Ninject;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class TaskCard
    {
        [JsonProperty("taskId")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Header is required")]
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("descr")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Task status is requried")]
        [JsonProperty("taskStatus")]
        public string TaskStatus { get; set; }

        [Required(ErrorMessage = "Card status is required")]
        [JsonProperty("cardStatus")]
        public string CardStatus { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [Required(ErrorMessage = "UpdatedAt is required")]
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        
        [JsonProperty("deadline")]
        public string Deadline { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [Required(ErrorMessage = "Priority is required")]
        [JsonProperty("priority")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Difficulty is required")]
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("comments")]
        public CommentBO[] Comments { get; set; }

        [JsonProperty("files")]
        public FileBO[] Files { get; set; }

        [JsonProperty("links")]
        public LinkBO[] Links { get; set; }

        [JsonProperty("subtasks")]
        public SubtaskBO[] Subtasks { get; set; }

        [JsonProperty("tags")]
        public TagBO[] Tags { get; set; }

        public TaskCard(Task entity)
        {
            TaskId = entity.Id;
            Header = entity.Header;
            Description = entity.Description;
            TaskStatus = entity.Status.Name;
            CardStatus = entity.CardStatus.Name;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
            Deadline = entity.Deadline;
            Progress = entity.Progress.Value;
            Priority = entity.Priority.Name;
            Difficulty = entity.Difficulty.Name;

            Comments = (from c in entity.Comments
                       select new CommentBO(c)).ToArray();

            Files = (from f in entity.AttachedFiles
                     select new FileBO(f)).ToArray();

            Links = (from l in entity.AttachedLinks
                     select new LinkBO(l)).ToArray();

            Subtasks = (from s in entity.Subtasks
                        select new SubtaskBO(s)).ToArray();

            var ts = NinjectKernel.Kernel.Get<Services.Core.Interfaces.ITagService>();

            Tags = (from x in entity.TagReferences
                    select ts.GetTagAsync(x.TagId).Result).ToArray();
        }
    }
}
