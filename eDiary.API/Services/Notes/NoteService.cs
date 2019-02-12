using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Note.Interfaces;

namespace eDiary.API.Services.Note
{
    public class NoteService: INoteService
    {
        private readonly IUnitOfWork uow;

        public NoteService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
