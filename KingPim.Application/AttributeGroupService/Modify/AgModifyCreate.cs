using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public class AgModifyCreate : IAgModifyCreate
    {
        public readonly KingPimDbContext _context;

        public AgModifyCreate(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(AgModifyCreateModel model)
        {
            try
            {
                var entity = new AttributeGroup
                {

                    Id = model.Id,
                    Name = model.Name
                };
                _context.AttributeGroups.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                throw e;
            }

        }
    }
}