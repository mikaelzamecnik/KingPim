using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public interface IAgModifyCreate
    {
        Task Execute(AgModifyCreateModel model);
    }
}