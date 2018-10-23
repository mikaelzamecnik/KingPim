using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public interface ICategoryModifyCreate
    {
        Task Execute(CategoryModifyCreateModel model);
    }
}