using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class SubtaskBO
    {
        [JsonProperty("subtaskId")]
        public int SubtaskId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("isCompleted")]
        public int? IsCompleted { get; set; }
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
