using eDiary.API.Models.EF.Interfaces;
using eDiary.API.Services.Interfaces;

namespace eDiary.API.Services
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
