using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IAttributeOptionListRepo
    {
        Task<IEnumerable<AttributeOptionListModel>> GetAttributeOptionLists();
        Task<AttributeOptionListModel> GetAttributeOptionList(int id);
        Task CreateAttributeOptionList(AttributeOptionListModel model);
    }
}
