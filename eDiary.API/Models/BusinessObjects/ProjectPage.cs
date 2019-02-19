using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectPage
    {
        [JsonProperty("name")]
        public string Name { get; set; }
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
