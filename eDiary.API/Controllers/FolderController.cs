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
    public class FolderController: ApiController
    {
        private readonly IFolderService ns;

        public FolderController()
        {
            ns = NinjectKernel.Kernel.Get<IFolderService>();
        }

        [HttpGet]
        public async Task<IEnumerable<FolderBO>> GetAllFoldersAsync()
        {
            return await ns.GetAllFoldersAsync();
        }

        [HttpGet]
        public async Task<FolderBO> GetFolderByIdAsync(int? id)
        {
            Validate(id);
            return await ns.GetFolderAsync((int)id);
        }

        [HttpPost]
        public async Task CreateFolderAsync(FolderBO folder)
        {
            Validate(folder);
            await ns.CreateFolderAsync(folder);
        }

        [HttpPut]
        public void UpdateFolderAsync(FolderBO folder)
        {
            Validate(folder);
            ns.UpdateFolder(folder);
        }

        [HttpDelete]
        public async Task DeleteNoteByIdAsync(int? id)
        {
            Validate(id);
            await ns.DeleteFolderAsync((int)id);
        }
    }
}
