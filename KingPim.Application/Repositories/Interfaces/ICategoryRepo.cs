using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface ICategoryRepo
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int id);
        Task CreateCategory(CategoryModel model);
        Task UpdateCategory(CategoryModel model);
        Task DeleteCategory(int id);
        IEnumerable<Category> GetAllCategoriesExport();
    }
}
