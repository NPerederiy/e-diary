using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class CommentBO
    {
        [JsonProperty("commentId")]
        public int CommentId { get; set; }
        [JsonProperty("taskId")]
        public int TaskId { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
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
