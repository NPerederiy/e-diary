using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class CreateSectionData
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public CreateSectionData(int projectId, string name)
        {
            ProjectId = projectId;
            Name = name;
        }
    }
}
