using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class CreateTaskResponseData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        public CreateTaskResponseData(int id, string createdAt, string updatedAt)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }
    }
}
