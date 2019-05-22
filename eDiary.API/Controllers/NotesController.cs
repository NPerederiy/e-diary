using eDiary.API.Filters;
using eDiary.API.Models.BusinessObjects;
using eDiary.API.Services.Notes.Interfaces;
using eDiary.API.Util;
using Ninject;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eDiary.API.Controllers
{
    [JwtAuthentication]
    [ConsoleLogger]
    [ExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NotesController : ApiController
    {
        private readonly INoteService ns;

        public NotesController()
        {
            ns = NinjectKernel.Kernel.Get<INoteService>();
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCard>> GetAllNotesAsync()
        {
            return await ns.GetAllNotesAsync();
        }

        [HttpGet]
        public async Task<NoteCard> GetNoteByIdAsync(int? id)
        {
            Validate(id);
            return await ns.GetNoteAsync((int)id);
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCard>> GetNotesByTagAsync(int? tag)
        {
            Validate(tag);
            return await ns.GetNotesByTagAsync((int)tag);
        }

        [HttpPost]
        public async Task CreateNoteAsync(NoteCard note)
        {
            Validate(note);
            await ns.CreateNoteAsync(note);
        }

        [HttpPut]
        public async Task UpdateNoteAsync(NoteCard note)
        {
            Validate(note);
            await ns.UpdateNoteAsync(note);
        }

        [HttpDelete]
        public async Task DeleteNoteByIdAsync(int? id)
        {
            Validate(id);
            await ns.DeleteNoteAsync((int)id);
        }
    }
}
