using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace eDiary.API.Models.BusinessObjects
{
    public class SectionCard
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("sectionId")]
        public int SectionId { get; set; }
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        [JsonProperty("tasks")]
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