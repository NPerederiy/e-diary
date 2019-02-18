using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class FileBO
    {
        [JsonProperty("fileId")]
        public int FileId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("taskId")]
        public int? TaskId { get; set; }
        [JsonProperty("noteId")]
        public int? NoteId { get; set; }

        public FileBO(AttachedFile entity)
        {
            FileId = entity.Id;
            Name = entity.Name;
            Link = entity.Link;
            TaskId = entity.TaskId;
            NoteId = entity.NoteId;
        }
    }
}
