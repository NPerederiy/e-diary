using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class SubtaskBO
    {
        [JsonProperty("subtaskId")]
        public int SubtaskId { get; set; }

        [Required(ErrorMessage = "Subtask text is required")]
        [JsonProperty("text")]
        public string Text { get; set; }

        [Required(ErrorMessage = "IsCompleted is required")]
        [JsonProperty("isCompleted")]
        public int? IsCompleted { get; set; }

        [Required(ErrorMessage = "Task ID is required")]
        [JsonProperty("taksId")]
        public int? TaskId { get; set; }

        public SubtaskBO(Subtask entity)
        {
            SubtaskId = entity.Id;
            Text = entity.Text;
            IsCompleted = entity.IsCompleted;
            TaskId = entity.TaskId;
        }
    }
}
