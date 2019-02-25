using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class FileBO
    {
        [JsonProperty("fileId")]
        public int FileId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Link is required")]
        [JsonProperty("link")]
        public string Link { get; set; }
        
        // TODO: Add validator -> both taskId and noteId can not be null in the same time

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
