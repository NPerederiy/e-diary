using eDiary.API.Models.Entities;
using System.Collections.Generic;

namespace eDiary.API.Models.BusinessObjects
{
    public class SectionCard
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public TaskCard[] Tasks { get; set; }

        public SectionCard(Section entity)
        {
            SectionId = entity.Id;
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