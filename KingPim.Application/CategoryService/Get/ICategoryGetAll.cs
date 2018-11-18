using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Get
{
    public interface ICategoryGetAll
    {
        Task<IEnumerable<CategoryGetAllModel>> Execute();
        IEnumerable<Category> GetAllCategories();
    }
}