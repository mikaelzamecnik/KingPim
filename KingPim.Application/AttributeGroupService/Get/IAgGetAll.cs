using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeGroupService.Get
{
    public interface IAgGetAll
    {
        Task<IEnumerable<AgGetAllModel>> Execute();
    }
}