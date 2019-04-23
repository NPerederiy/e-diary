using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Notes.Interfaces;
using eDiary.API.Services.Validation;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities = eDiary.API.Models.Entities;

namespace eDiary.API.Services.Notes
{
    public class NoteService: BaseService, INoteService
    {
        private readonly IUnitOfWork uow;

        public NoteService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<NoteCard>> GetAllNotesAsync()
        {
            var notes = await uow.NoteRepository.GetAllAsync();
            return ConvertToNoteCards(notes);
        }

        public async Task<IEnumerable<NoteCard>> GetNotesByTagAsync(int tagId)
        {
            var tag = await FindTagAsync(x => x.Id == tagId);
            var notes = new List<NoteCard>();

            foreach(var x in tag.TagReferences)
            {
                if (x.NoteId != null)
                    notes.Add(await GetNoteAsync((int)x.NoteId));
            }

            return notes.ToArray();
        }

        public async Task<NoteCard> GetNoteAsync(int noteId)
        {
            return new NoteCard(await FindNoteAsync(x => x.Id == noteId));
        }
        
        public async Task CreateNoteAsync(NoteCard card)
        {
            Validate.NotNull(card, "Note card");
            var n = new Entities.Note
            {
                Header = card.Header,
                Description = card.Description,
                CreatedAt = card.CreatedAt,
                UpdatedAt = card.CreatedAt,
                Status = await FindEntityAsync(uow.StatusRepository, x => x.Name == card.CardStatus),
                FolderId = card.FolderId
            };

            await uow.NoteRepository.CreateAsync(n);
        }
        
        public async Task UpdateNoteAsync(NoteCard card)
        {
            Validate.NotNull(card, "Note card");
            var note = await FindNoteAsync(x => x.Id == card.NoteId);
            note.Header = card.Header;
            note.Description = card.Description;
            note.CreatedAt = card.CreatedAt;
            note.UpdatedAt = card.UpdatedAt;
            note.FolderId = card.FolderId;
            note.Status = await FindEntityAsync(uow.StatusRepository, x => x.Name == card.CardStatus);

            uow.NoteRepository.Update(note);
        }
        
        public async Task DeleteNoteAsync(int id)
        {
            uow.NoteRepository.Delete(await FindNoteAsync(x => x.Id == id));
        }

        private async Task<Entities.Note> FindNoteAsync(Expression<Func<Entities.Note, bool>> condition)
        {
            return await FindEntityAsync(uow.NoteRepository, condition);
        }

        private async Task<Entities.Tag> FindTagAsync(Expression<Func<Entities.Tag, bool>> condition)
        {
            return await FindEntityAsync(uow.TagRepository, condition);
        }

        private static List<NoteCard> ConvertToNoteCards(IEnumerable<Entities.Note> notes)
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
