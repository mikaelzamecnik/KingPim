using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface ISubCategoryRepo
    {
        Task<IEnumerable<SubCategoryModel>> GetSubcategories();
        Task<SubCategoryModel> GetSubcategory(int id);
        Task CreateSubcategory(SubCategoryModel model);
        Task UpdateSubcategory(SubCategoryModel model);
        Task DeleteSubcategory(int id);
        IEnumerable<SubCategory> GetAllSubCategoriesExport();
    }
}
