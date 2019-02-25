using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Notes.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteCard>> GetAllNotesAsync();
        Task<IEnumerable<NoteCard>> GetFolderNotesAsync(int sectionId);
        Task<IEnumerable<NoteCard>> GetNotesByTagAsync(int tagId);
        Task<NoteCard> GetNoteAsync(int noteId);
        Task CreateNoteAsync(NoteCard task);
        Task UpdateNoteAsync(NoteCard task);
        Task DeleteNoteAsync(int noteId);
    }
}
