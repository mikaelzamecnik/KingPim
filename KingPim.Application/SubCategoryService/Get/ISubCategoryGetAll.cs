using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Get
{
    public interface ISubCategoryGetAll
    {
        Task<IEnumerable<SubCategoryGetAllModel>> Execute();
        IEnumerable<SubCategory> GetAllSubCategories();
    }
}