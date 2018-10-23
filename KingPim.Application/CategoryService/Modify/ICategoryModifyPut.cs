using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.CategoryService.Modify
{
    public interface ICategoryModifyPut
    {
        Task Execute(CategoryModifyPutModel model);
    }
}