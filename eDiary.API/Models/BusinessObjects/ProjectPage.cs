using eDiary.API.Models.EF.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

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

        public ProjectPage(int projectId, IUnitOfWork uow)
        {
            var p = (uow.ProjectRepository.GetByConditionAsync(x => x.Id == projectId).Result).FirstOrDefault();
            if(p == null) throw new System.Exception("Not found");
            ProjectId = projectId;
            Name = p.Name;

            var cards = new List<SectionCard>();
            foreach(var s in p.Sections)
            {
                cards.Add(new SectionCard(s));
            }

            Sections = cards.ToArray();
        }
    }
}
