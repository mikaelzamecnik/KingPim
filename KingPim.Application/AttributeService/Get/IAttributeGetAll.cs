using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeService.Get
{
    public interface IAttributeGetAll
    {
        Task<IEnumerable<AttributeGetAllModel>> Execute();
    }
}