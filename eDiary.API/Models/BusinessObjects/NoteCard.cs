using eDiary.API.Models.Entities;
using eDiary.API.Util;
using Newtonsoft.Json;
using Ninject;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace eDiary.API.Models.BusinessObjects
{
    public class NoteCard
    {
        [JsonProperty("noteId")]
        public int NoteId { get; set; }

        [Required(ErrorMessage = "Folder ID is required")]
        [JsonProperty("folderId")]
        public int FolderId { get; set; }

        [Required(ErrorMessage = "Header is required")]
        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("descr")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Card status is required")]
        [JsonProperty("cardStatus")]
        public string CardStatus { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }

        [Required(ErrorMessage = "UpdatedAt is required")]
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("tags")]
        public TagBO[] Tags { get; set; }

        public NoteCard(Note entity)
        {
            NoteId = entity.Id;
            FolderId = entity.FolderId;
            Header = entity.Header;
            Description = entity.Description;
            CardStatus = entity.Status.Name;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;

            var ts = NinjectKernel.Kernel.Get<Services.Core.Interfaces.ITagService>();

            Tags = (from x in entity.TagReferences
                    select ts.GetTagAsync(x.TagId).Result).ToArray();
        }
    }
}
