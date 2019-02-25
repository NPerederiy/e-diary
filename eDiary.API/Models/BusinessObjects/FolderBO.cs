using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class FolderBO
    {
        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public NoteCard[] Notes { get; set; }

        [JsonProperty("folders")]
        public FolderBO[] Folders { get; set; }

        public FolderBO(Folder entity)
        {
            Name = entity.Name;

            Notes = (from n in entity.Notes
                     select new NoteCard(n)).ToArray();

            Folders = (from f in entity.Folders
                       select new FolderBO(f)).ToArray(); 
        }
    }
}
