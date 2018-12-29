using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IAttributeOptionListRepo
    {
        Task<IEnumerable<AttributeOptionListModel>> GetAttributeOptionList();
        Task<AttributeOptionListModel> GetAttributeOptionValue(int id);
        Task CreateAttributeOptionList(AttributeOptionListModel model);
    }
}
