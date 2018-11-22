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
        public IEnumerable<AttributeGroup> AttributeGroups => _context.AttributeGroups;
        public async Task Execute(AgModifyCreateModel model)
        {
            if (model.Id == 0)     // Create
            {
                var attrGroup = new AttributeGroup
                {
                    
                    SubCategoryId = model.SubCategoryId,
                    Name = model.Name,
                    Description = model.Description,
                    SingleAttribute = null
                };
                _context.AttributeGroups.Add(attrGroup);
            }
            else       // Update
            {
                var ctxAttributeGroup = _context.AttributeGroups.FirstOrDefault(ag => ag.Id.Equals(model.Id));
                if (ctxAttributeGroup != null)
                {

                    ctxAttributeGroup.Name = model.Name;
                    ctxAttributeGroup.Description = model.Description;
                }
            }
           await _context.SaveChangesAsync();

        }
    }
}