using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;


namespace KingPim.Application.AttributeService.Get
{
    public class AttributeGetSingle : IAttributeGetSingle
    {
        public readonly KingPimDbContext _context;

        public AttributeGetSingle(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task<AttributeGetSingleModel> Execute(int id)
        {
            var entity = await _context.SingleAttributes.FindAsync(id);

            if (entity == null)
                return null;

            return new AttributeGetSingleModel
            {
                Id = entity.Id,
                Name = entity.Name,
                AttributeGroupId = entity.AttributeGroupId,
                AttributeValues = entity.AttributeValues
            };
        }
    }
}