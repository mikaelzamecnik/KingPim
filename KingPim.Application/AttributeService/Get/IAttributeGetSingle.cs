using System.Collections.Generic;
using System.Threading.Tasks;


namespace KingPim.Application.AttributeService.Get
{
    public interface IAttributeGetSingle
    {
        Task<AttributeGetSingleModel> Execute(int id);
    }
}