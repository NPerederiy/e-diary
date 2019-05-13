using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class SectionCard
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Section ID is required")]
        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("cards")]
        public TaskCard[] Tasks { get; set; }

        public SectionCard(Section entity)
        {
            SectionId = entity.Id;
            ProjectId = entity.ProjectId;
            Name = entity.Name;

            var cards = new List<TaskCard>();
            foreach(var t in entity.Tasks)
            {
                cards.Add(new TaskCard(t));
            }
            Tasks = cards.ToArray();
        }
    }
}