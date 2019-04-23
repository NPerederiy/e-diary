using eDiary.API.Models.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDiary.API.Services.Notes.Interfaces
{
    public interface IFolderService
    {
        Task<IEnumerable<FolderBO>> GetAllFoldersAsync();
        Task<FolderBO> GetFolderAsync(int id);
        Task CreateFolderAsync(FolderBO folder);
        void UpdateFolder(FolderBO folder);
        Task DeleteFolderAsync(int id);
    }
}
