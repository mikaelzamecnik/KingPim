using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeGroupService.Get
{
    public class AgGetAll:IAgGetAll
    {
        public readonly KingPimDbContext _context;

        public AgGetAll(KingPimDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AttributeGroup> AttributeGroups => _context.AttributeGroups.Include(c => c.Id).Include(d => d.Id);
        public async Task<IEnumerable<AgGetAllModel>> Execute()
        {
            return await _context.AttributeGroups.Select(c =>
                new AgGetAllModel
                {
                 Id = c.Id,
                 Name = c.Name,
                 Description = c.Description,
                 SingleAttribute = c.SingleAttribute

        }).ToListAsync();
        }
    }
}