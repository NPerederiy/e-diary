using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface IProjectCategoryService
    {
        Task<IEnumerable<ProjectCategoryCard>> GetAllCategoriesAsync();
        Task<IEnumerable<ProjectCategoryCard>> GetCategoriesByProfileIdAsync(int profileId);
        Task<ProjectCategoryCard> GetCategoryAsync(int id);
        Task<int> CreateCategoryAsync(string name, int profileId);
        Task UpdateCategoryAsync(int id, string name);
        Task DeleteCategoryAsync(int id);
    }
}
