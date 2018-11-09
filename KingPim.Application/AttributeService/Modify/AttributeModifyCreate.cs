using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeService.Modify
{
    public class AttributeModifyCreate : IAttributeModifyCreate
    {
        public readonly KingPimDbContext _context;

        public AttributeModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(AttributeModifyCreateModel model)
        {
            try
            {
                var entity = new SingleAttribute
                {

                    SingleAttributeId = model.SingleAttributeId,
                    Name = model.Name,
                    AttributeGroupId = model.AttributeGroupId
                };
                _context.SingleAttributes.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw e;
            }

        }
    }
}