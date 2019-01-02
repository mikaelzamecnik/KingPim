using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IAttributeOptionListValueRepo
    {
        Task<IEnumerable<AttributeOptionListValueModel>> GetAttributeOptionListValues();
        Task<AttributeOptionListValueModel> GetAttributeOptionListValue(int id);
        Task CreateAttributeOptionListValue(AttributeOptionListValueModel model);
    }
}
