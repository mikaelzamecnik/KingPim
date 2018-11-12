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

        public IEnumerable<SingleAttribute> SingleAttributes => _context.SingleAttributes.Include(c => c.Id).Include(d => d.Id);
        public async Task<IEnumerable<AttributeGetAllModel>> Execute()
        {
            return await _context.SingleAttributes.Select(c =>
                new AttributeGetAllModel
                {
                 Id = c.Id,
                 Name = c.Name,
                 AttributeGroupId = c.AttributeGroupId,
                 Description = c.Description,
                 Type = c.Type

        }).ToListAsync();
        }
    }
}