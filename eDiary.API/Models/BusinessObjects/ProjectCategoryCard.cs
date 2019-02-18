using eDiary.API.Models.Entities;
using System.Collections.Generic;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectCategoryCard
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public ProjectCard[] Projects { get; set; }

        public ProjectCategoryCard(ProjectCategory entity)
        {
            Name = entity.Name;
            CategoryId = entity.Id;
            var cards = new List<ProjectCard>();
            foreach(var p in entity.Projects)
            {
                cards.Add(new ProjectCard(p));
            }
            Projects = cards.ToArray();
        }
    }
}
