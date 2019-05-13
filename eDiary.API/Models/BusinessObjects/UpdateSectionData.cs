using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class UpdateSectionData
    {
        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        public UpdateSectionData(int sectionId, string name, int projectId)
        {
            SectionId = sectionId;
            Name = name;
            ProjectId = projectId;
        }
    }
}
