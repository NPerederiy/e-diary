using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectCard
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("projectName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }
        
        [JsonProperty("hotTaskCount")]
        public int HotTaskCount { get; set; }
        
        [JsonProperty("importantTaskCount")]
        public int ImportantTaskCount { get; set; }
        
        [JsonProperty("completedTaskCount")]
        public int CompletedTaskCount { get; set; }
        
        [JsonProperty("inProgressTaskCount")]
        public int InProgressTaskCount { get; set; }
        
        [JsonProperty("overdueTaskCount")]
        public int OverdueTaskCount { get; set; }
        
        [JsonProperty("totalTaskCount")]
        public int TotalTaskCount { get; set; }

        private List<Task> Tasks { get; set; }  

        public ProjectCard(Project entity)
        {
            Name = entity.Name;
            ProjectId = entity.Id;
            Tasks = new List<Task>();
            foreach(var s in entity.Sections)
            {
                Tasks.AddRange(s.Tasks);
            }
            HotTaskCount = CalcHotTaskCount();
            ImportantTaskCount = CalcImportantTaskCount();
            CompletedTaskCount = CalcCompletedTaskCount();
            InProgressTaskCount = CalcInProgressTaskCount();
            OverdueTaskCount = CalcOverdueTaskCount();
            TotalTaskCount = CalcTotalTaskCount();
        }

        private int CalcCompletedTaskCount()
        {
            var counter = 0;
            foreach (var t in Tasks)
            {
                if (t.CardStatus.Name.ToLower() == "completed")
                    counter++;
            }
            return counter;
        }

        private int CalcHotTaskCount()
        {
            var counter = 0;
            foreach (var t in Tasks)
            {
                if (t.CardStatus.Name.ToLower() == "hot")
                    counter++;
            }
            return counter;
        }

        private int CalcImportantTaskCount()
        {
            var counter = 0;
            foreach (var t in Tasks)
            {
                if (t.CardStatus.Name.ToLower() == "important")
                    counter++;
            }
            return counter;
        }

        private int CalcInProgressTaskCount()
        {
            var counter = 0;
            foreach (var t in Tasks)
            {
                if (t.Status.Name.ToLower() == "in progress")
                    counter++;
            }
            return counter;
        }

        private int CalcOverdueTaskCount()
        {
            var counter = 0;
            foreach (var t in Tasks)
            {
                if (t.CardStatus.Name.ToLower() == "overdue")
                    counter++;
            }
            return counter;
        }

        private int CalcTotalTaskCount()
        {
            return CompletedTaskCount + ImportantTaskCount + HotTaskCount + OverdueTaskCount;
        }

    }
}
