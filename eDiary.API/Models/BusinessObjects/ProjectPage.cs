using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectPage
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("sections")]
        public SectionCard[] Sections { get; set; }

        public ProjectPage(Project entity)
        {
            ProjectId = entity.Id;
            Name = entity.Name;

            var cards = new List<SectionCard>();
            foreach(var s in entity.Sections)
            {
                cards.Add(new SectionCard(s));
            }

            Sections = cards.ToArray();
        }
    }
}
