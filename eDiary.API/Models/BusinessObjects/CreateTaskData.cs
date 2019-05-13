using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class CreateTaskData
    {
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        public CreateTaskData(string header, int sectionId)
        {
            Header = header;
            SectionId = sectionId;
        }
    }
}
