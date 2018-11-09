using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public class AgModifyDelete: IAgModifyDelete
    {
        public readonly KingPimDbContext _context;

        public AgModifyDelete(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(int id)
        {
            var entity = await _context.AttributeGroups.SingleAsync(c => c.Id == id);
            _context.AttributeGroups.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}