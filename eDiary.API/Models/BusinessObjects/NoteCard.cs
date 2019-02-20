using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class NoteCard
    {
        [JsonProperty("noteId")]
        public int NoteId { get; set; }
        [JsonProperty("folderId")]
        public int FolderId { get; set; }
        [JsonProperty("header")]
        public string Header { get; set; }
        [JsonProperty("descr")]
        public string Description { get; set; }
        [JsonProperty("cardStatus")]
        public string CardStatus { get; set; }
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }
        [JsonProperty("tags")]
        public TagBO[] Tags { get; set; }

        public NoteCard(Note entity)
        {
            NoteId = entity.Id;
            FolderId = entity.FolderId;
            Header = entity.Header;
            Description = entity.Description;
            CardStatus = entity.Status.Name;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
            Tags = (from t in entity.GetTags()
                   select new TagBO(t)).ToArray();
        }
    }
}
