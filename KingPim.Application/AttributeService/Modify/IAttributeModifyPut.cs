using System.Collections.Generic;
using System.Threading.Tasks;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeService.Modify
{
    public interface IAttributeModifyPut
    {
        Task Execute(AttributeModifyPutModel model);
    }
}