using System.Collections.Generic;
using System.Linq;
using eDiary.API.Models.Entities;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Notes.Interfaces;
using System;

namespace eDiary.API.Services.Notes
{
    public class NoteService: INoteService
    {
        private readonly IUnitOfWork uow;

        public NoteService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async System.Threading.Tasks.Task<IEnumerable<NoteCard>> GetAllNotesAsync()
        {
            var notes = await uow.NoteRepository.GetAllAsync();
            return ConvertToNoteCards(notes);
        }

        public async System.Threading.Tasks.Task<IEnumerable<NoteCard>> GetFolderNotesAsync(int folderId)
        {
            var folder = (await uow.FolderRepository.GetByConditionAsync(x => x.Id == folderId)).FirstOrDefault();
            if (folder == null) throw new Exception("Folder not found");
            return ConvertToNoteCards(folder.Notes);
        }

        public async System.Threading.Tasks.Task<NoteCard> GetNoteAsync(int id)
        {
            var note = (await uow.NoteRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (note == null) throw new Exception("Note not found");
            return new NoteCard(note);
        }

        public async void CreateNote(NoteCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));

            var n = new Note
            {
                Header = card.Header,
                Description = card.Description,
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.CreatedAt,
                Status = (await uow.StatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault(),
                FolderId = card.FolderId
            };

            await uow.NoteRepository.CreateAsync(n);
        }

        public async void UpdateNote(NoteCard card)
        {
            if (card == null) throw new ArgumentNullException(nameof(card));
            if (card.CardStatus == null) throw new ArgumentNullException(nameof(card.CardStatus));

            var note = (await uow.NoteRepository.GetByConditionAsync(x => x.Id == card.NoteId)).FirstOrDefault();
            if (note == null) throw new Exception("Note not found");

            note.Header = card.Header;
            note.Description = card.Description;
            note.CreatedAt = card.CreatedAt;
            note.UpdatedAt = card.UpdatedAt;
            note.FolderId = card.FolderId;
            note.Status = (await uow.StatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault();

            uow.NoteRepository.Update(note);
        }

        public async void DeleteNote(int id)
        {
            var note = (await uow.NoteRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (note == null) throw new Exception("Note not found");
            uow.NoteRepository.Delete(note);
        }

        private static List<NoteCard> ConvertToNoteCards(IEnumerable<Note> notes)
        {
            var cards = new List<NoteCard>();
            foreach (var n in notes)
            {
                cards.Add(new NoteCard(n));
            }
            return cards;
        }
    }
}
