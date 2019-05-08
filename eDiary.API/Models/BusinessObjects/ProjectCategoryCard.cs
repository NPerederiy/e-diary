using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectCategoryCard
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category ID is required")]
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        
        [JsonProperty("projects")]
        public ProjectCard[] Projects { get; set; }

        public ProjectCategoryCard(ProjectCategory entity)
        {
            Name = entity.Name;
            CategoryId = entity.Id;

            var cards = new List<ProjectCard>();
            if (entity.Projects != null)
                foreach(var p in entity.Projects)
                {
                    cards.Add(new ProjectCard(p));
                }
            Projects = cards.ToArray();
        }
    }
}
