using eDiary.API.Models.BusinessObjects;
using eDiary.API.Models.EF.Interfaces;
using Entities = eDiary.API.Models.Entities;
using eDiary.API.Services.Notes.Interfaces;
using eDiary.API.Util;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.API.Services.Notes
{
    public class FolderService : BaseService, IFolderService
    {
        private readonly IUnitOfWork uow;

        public FolderService()
        {
            uow = NinjectKernel.Kernel.Get<IUnitOfWork>();
        }

        public async Task<IEnumerable<FolderBO>> GetAllFoldersAsync()
        {
            var folders = await uow.FolderRepository.GetAllAsync();
            return ConvertToBusinessObjects(folders);
        }

        public async Task<FolderBO> GetFolderAsync(int id)
        {
            return new FolderBO(await FindFolderAsync(x => x.Id == id));
        }

        public async Task CreateFolderAsync(FolderBO folder)
        {
            Validation.Validate.NotNull(folder);

            var entity = new Entities.Folder
            {
                Name = folder.Name,
                ParentFolderId = folder.ParentFolderId
            };

            await uow.FolderRepository.CreateAsync(entity);
        }

        public void UpdateFolder(FolderBO folder)
        {
            Validation.Validate.NotNull(folder);

            var entity = new Entities.Folder
            {
                Id = folder.Id,
                Name = folder.Name,
                ParentFolderId = folder.ParentFolderId      
            };

            uow.FolderRepository.Update(entity);
        }

        public async Task DeleteFolderAsync(int id)
        {
            uow.FolderRepository.Delete(await FindFolderAsync(x => x.Id == id));
        }

        private async Task<Entities.Folder> FindFolderAsync(Expression<Func<Entities.Folder, bool>> condition)
        {
            return await FindEntityAsync(uow.FolderRepository, condition);
        }

        private List<FolderBO> ConvertToBusinessObjects(IEnumerable<Entities.Folder> folders)
        {
            var list = new List<FolderBO>();
            foreach (var f in folders)
            {
                list.Add(new FolderBO(f));
            }
            return list;
        }
    }
}
