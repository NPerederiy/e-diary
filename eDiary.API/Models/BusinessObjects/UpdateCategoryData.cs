using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class UpdateCategoryData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public UpdateCategoryData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
