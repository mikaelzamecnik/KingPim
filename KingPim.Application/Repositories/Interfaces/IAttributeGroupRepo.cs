using KingPim.Application.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories.Interfaces
{
    public interface IAttributeGroupRepo
    {
        Task<IEnumerable<AttributeGroupModel>> GetAttributegroups();
        Task<AttributeGroupModel> GetAttributegroup(int id);
        Task CreateAttributegroup(AttributeGroupModel model);
        Task UpdateAttributegroup(AttributeGroupModel model);
        Task DeleteAttributegroup(int id);
    }
}
