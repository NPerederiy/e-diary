using eDiary.API.Models.Entities;

namespace eDiary.API.Models.BusinessObjects
{
    public class NoteCard
    {
        public int NoteId { get; set; }
        public int FolderId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string CardStatus { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

        public NoteCard(Note entity)
        {
            NoteId = entity.Id;
            FolderId = entity.FolderId;
            Header = entity.Header;
            Description = entity.Description;
            CardStatus = entity.Status.Name;
            CreatedAt = entity.CreatedAt;
            UpdatedAt = entity.UpdatedAt;
        }
    }
}
