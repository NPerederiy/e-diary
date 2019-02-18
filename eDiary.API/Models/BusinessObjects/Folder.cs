using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class Folder
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("notes")]
        public NoteCard[] Notes { get; set; }
        [JsonProperty("folders")]
        public Folder[] Folders { get; set; }
    }
}
