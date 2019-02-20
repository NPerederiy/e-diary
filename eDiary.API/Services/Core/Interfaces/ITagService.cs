using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagBO>> GetAllTagsAsync();
        Task<TagBO> GetTagAsync(int id);
        void CreateTagAsync(TagBO tag);
        void UpdateTagAsync(TagBO tag);
        void DeleteTagAsync(int id);
    }
}
