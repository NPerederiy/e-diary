using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.API.Models.BusinessObjects
{
    public class UpdateProjectData
    {
        [JsonProperty("projectId")]
        public int ProjectId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoryId")]
        public int? CategoryId { get; set; }

        public UpdateProjectData(int projectId, string name, int? categoryId)
        {
            ProjectId = projectId;
            Name = name;
            CategoryId = categoryId;
        }
    }
}
