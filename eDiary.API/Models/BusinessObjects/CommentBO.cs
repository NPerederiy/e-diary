using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class CommentBO
    {
        [JsonProperty("commentId")]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Task ID is required")]
        [JsonProperty("taskId")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Comment text is required")]
        [JsonProperty("text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        public CommentBO(Comment entity)
        {
            CommentId = entity.Id;
            TaskId = entity.TaskId;
            Text = entity.Text;
            CreatedAt = entity.CreatedAt;
        }
    }
}
