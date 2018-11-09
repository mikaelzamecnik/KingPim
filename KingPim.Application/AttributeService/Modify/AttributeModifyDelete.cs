using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;

namespace KingPim.Application.AttributeService.Modify
{
    public class AttributeModifyDelete: IAttributeModifyDelete
    {
        public readonly KingPimDbContext _context;

        public AttributeModifyDelete(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.SingleAttributes.SingleAsync(c => c.SingleAttributeId == id);
            _context.SingleAttributes.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}