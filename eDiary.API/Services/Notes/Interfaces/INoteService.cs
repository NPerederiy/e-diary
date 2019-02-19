using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Notes.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteCard>> GetAllNotesAsync();
        Task<IEnumerable<NoteCard>> GetFolderNotesAsync(int sectionId);
        Task<NoteCard> GetNoteAsync(int id);
        void CreateNoteAsync(NoteCard task);
        void UpdateNoteAsync(NoteCard task);
        void DeleteNoteAsync(int id);
    }
}
