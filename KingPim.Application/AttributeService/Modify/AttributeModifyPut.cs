using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeService.Modify
{
    public class AttributeModifyPut : IAttributeModifyPut
    {
        public readonly KingPimDbContext _context;

        public AttributeModifyPut(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(AttributeModifyPutModel model)
        {
            try
            {
                var entity =  await _context.SingleAttributes.SingleOrDefaultAsync(c => c.Id == model.Id);


                entity.Name = model.Name;
                entity.AttributeGroupId = model.AttributeGroupId;
                entity.AttributeValues = model.AttributeValues;

                _context.SingleAttributes.Update(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }
    }
}