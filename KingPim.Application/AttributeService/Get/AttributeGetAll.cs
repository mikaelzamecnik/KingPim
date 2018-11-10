using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeService.Get
{
    public class AttributeGetAll:IAttributeGetAll
    {
        public readonly KingPimDbContext _context;

        public AttributeGetAll(KingPimDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SingleAttribute> SingleAttributes => _context.SingleAttributes.Include(c => c.SingleAttributeId).Include(d => d.SingleAttributeId);
        public async Task<IEnumerable<AttributeGetAllModel>> Execute()
        {
            return await _context.SingleAttributes.Select(c =>
                new AttributeGetAllModel
                {
                 SingleAttributeId = c.SingleAttributeId,
                 Name = c.Name,
                 AttributeGroupId = c.AttributeGroupId

        }).ToListAsync();
        }
    }
}