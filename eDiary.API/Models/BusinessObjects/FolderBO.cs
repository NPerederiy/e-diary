using eDiary.API.Models.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class FolderBO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("notes")]
        public NoteCard[] Notes { get; set; }

        [JsonProperty("folders")]
        public FolderBO[] Folders { get; set; }

        [JsonProperty("parentFolderId")]
        public int? ParentFolderId { get; set; }

        public FolderBO(Folder entity)
        {
            Id = entity.Id;

            Name = entity.Name;

            ParentFolderId = entity.ParentFolderId;

            Notes = (from n in entity.Notes
                     select new NoteCard(n)).ToArray();

            Folders = (from f in entity.Folders
                       select new FolderBO(f)).ToArray(); 
        }
    }
}
