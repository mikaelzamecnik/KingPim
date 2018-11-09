using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.AttributeService.Modify
{
    public interface IAttributeModifyDelete
    {
        Task Execute(int id);
    }
}