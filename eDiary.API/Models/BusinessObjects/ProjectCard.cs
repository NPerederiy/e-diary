﻿using eDiary.API.Models.Entities;
using System.Collections.Generic;

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
