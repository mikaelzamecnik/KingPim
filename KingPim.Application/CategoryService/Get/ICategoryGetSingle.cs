using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Get
{
    public interface ICategoryGetSingle
    {
        Task<CategoryGetSingleModel> Execute(int id);
    }
}