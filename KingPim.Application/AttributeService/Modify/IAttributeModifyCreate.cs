using System.Collections.Generic;
using System.Threading.Tasks;

namespace KingPim.Application.AttributeService.Modify
{
    public interface IAttributeModifyCreate
    {
        Task Execute(AttributeModifyCreateModel model);
    }
}