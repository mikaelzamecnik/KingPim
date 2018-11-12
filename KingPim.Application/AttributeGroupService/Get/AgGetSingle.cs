using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;


namespace KingPim.Application.AttributeGroupService.Get
{
    public class AgGetSingle : IAgGetSingle
    {
        public readonly KingPimDbContext _context;

        public AgGetSingle(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<AgGetSingleModel> Execute(int id)
        {
            var entity = await _context.AttributeGroups.FindAsync(id);

            if (entity == null)
                return null;

            return new AgGetSingleModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description

            };
        }
    }
}