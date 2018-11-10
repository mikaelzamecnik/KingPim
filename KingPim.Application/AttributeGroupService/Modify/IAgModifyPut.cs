using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public interface IAgModifyPut
    {
        Task Execute(AgModifyPutModel model);
    }
}