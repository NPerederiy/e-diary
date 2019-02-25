using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class TagBO
    {
        [JsonProperty("tagId")]
        public int TagId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        public TagBO(Tag entity)
        {
            TagId = entity.Id;
            Name = entity.Name;
        }
    }
}
