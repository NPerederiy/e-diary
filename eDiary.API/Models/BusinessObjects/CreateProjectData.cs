using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class CreateProjectData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }

        public CreateProjectData(string name, int? categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }
    }
}
