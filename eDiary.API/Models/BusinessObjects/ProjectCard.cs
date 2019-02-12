using eDiary.API.Models.Entities;
using eDiary.API.Services.Tasks.Interfaces;

namespace eDiary.API.Models.BusinessObjects
{
    public class ProjectCard
    {
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int HotTaskCount { get; set; }
        public int ImportantTaskCount { get; set; }
        public int CompletedTaskCount { get; set; }
        public int InProgressTaskCount { get; set; }
        public int OverdueTaskCount { get; set; }
        public int TotalTaskCount { get; set; }

        public ProjectCard(Project entity, IProjectService ps)
        {
            Name = entity.Name;
            ProjectId = entity.Id;
            HotTaskCount = ps.CalcHotTaskCount();
            ImportantTaskCount = ps.CalcImportantTaskCount();
            CompletedTaskCount = ps.CalcCompletedTaskCount();
            InProgressTaskCount = ps.CalcInProgressTaskCount();
            OverdueTaskCount = ps.CalcOverdueTaskCount();
            TotalTaskCount = ps.CalcTotalTaskCount();
        }
    }
}
