using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.SubCategoryService.Modify
{
    public interface ISubCategoryModifyCreate
    {
        Task Execute(SubCategoryModifyCreateModel model);
    }
}