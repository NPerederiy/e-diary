using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class LinkBO
    {
        [JsonProperty("linkId")]
        public int LinkId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("taskId")]
        public int? TaskId { get; set; }
        [JsonProperty("noteId")]
        public int? NoteId { get; set; }

        public LinkBO(AttachedLink entity)
        {
            LinkId = entity.Id;
            Name = entity.Name;
            Link = entity.Link;
            TaskId = entity.TaskId;
            NoteId = entity.NoteId;
        }
    }
}
