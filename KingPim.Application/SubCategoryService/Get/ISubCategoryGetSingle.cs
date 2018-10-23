using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Get
{
    public interface ISubCategoryGetSingle
    {
        Task<SubCategoryGetSingleModel> Execute(int id);
    }
}