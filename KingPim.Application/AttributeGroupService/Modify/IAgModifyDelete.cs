using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public interface IAgModifyDelete
    {
        Task Execute(int id);
    }
}