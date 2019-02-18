using eDiary.API.Models.Entities;
using Newtonsoft.Json;

namespace eDiary.API.Models.BusinessObjects
{
    public class TagBO
    {
        [JsonProperty("tagId")]
        public int TagId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        public TagBO(Tag entity)
        {
            TagId = entity.Id;
            Name = entity.Name;
        }
    }
}
