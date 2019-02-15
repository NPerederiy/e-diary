﻿using eDiary.API.Models.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDiary.API.Services.Tasks.Interfaces
{
    public interface IProjectCategoryService
    {
        Task<IEnumerable<ProjectCategoryCard>> GetAllCategoriesAsync();
        Task<ProjectCategoryCard> GetCategoryAsync(int id);
        void CreateCategory(ProjectCategoryCard category);
        void UpdateCategory(ProjectCategoryCard category);
        void DeleteCategory(int id);
    }
}
