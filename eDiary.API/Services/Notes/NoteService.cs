using System.Collections.Generic;
using System.Linq;
using eDiary.API.Models.Entities;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Notes.Interfaces;
using System;
using eDiary.API.Services.Notes.Filters;

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
            Folder folder = await TryFindFolder(folderId);
            return ConvertToNoteCards(folder.Notes);
        }

        public async System.Threading.Tasks.Task<NoteCard> GetNoteAsync(int id)
        {
            return new NoteCard(await TryFindNote(id));
        }

        [VerifyNoteCard]
        public async void CreateNoteAsync(NoteCard card)
        {
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

        [VerifyNoteCard]
        public async void UpdateNoteAsync(NoteCard card)
        {
            var note = await TryFindNote(card.NoteId);

            note.Header = card.Header;
            note.Description = card.Description;
            note.CreatedAt = card.CreatedAt;
            note.UpdatedAt = card.UpdatedAt;
            note.FolderId = card.FolderId;
            note.Status = (await uow.StatusRepository.GetByConditionAsync(x => x.Name == card.CardStatus)).FirstOrDefault();

            uow.NoteRepository.Update(note);
        }

        public async void DeleteNoteAsync(int id)
        {
            uow.NoteRepository.Delete(await TryFindNote(id));
        }

        private async System.Threading.Tasks.Task<Folder> TryFindFolder(int folderId)
        {
            var folder = (await uow.FolderRepository.GetByConditionAsync(x => x.Id == folderId)).FirstOrDefault();
            if (folder == null) throw new Exception("Folder not found");
            return folder;
        }

        private async System.Threading.Tasks.Task<Note> TryFindNote(int id)
        {
            var note = (await uow.NoteRepository.GetByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (note == null) throw new Exception("Note not found");
            return note;
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
