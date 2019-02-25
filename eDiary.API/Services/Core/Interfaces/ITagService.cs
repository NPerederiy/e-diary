using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Core.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagBO>> GetAllTagsAsync();
        Task<TagBO> GetTagAsync(int id);
        Task CreateTagAsync(TagBO tag);
        Task UpdateTagAsync(TagBO tag);
        Task DeleteTagAsync(int id);
    }
}
