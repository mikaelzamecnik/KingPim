using System.Collections.Generic;
using System.Threading.Tasks;


namespace KingPim.Application.AttributeGroupService.Get
{
    public interface IAgGetSingle
    {
        Task<AgGetSingleModel> Execute(int id);
    }
}