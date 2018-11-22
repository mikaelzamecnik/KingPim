using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KingPim.Persistence;
using KingPim.Domain.Entities;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public class AgModifyPut : IAgModifyPut
    {
        public readonly KingPimDbContext _context;

        public AgModifyPut(KingPimDbContext context)
        {
            _context = context;
        }

        public async Task Execute(AgModifyPutModel model)
        {
           
                //var entity =  await _context.AttributeGroups.SingleOrDefaultAsync(c => c.Id == model.Id);


                //entity.Name = model.Name;
                //entity.Description = model.Description;

                //_context.AttributeGroups.Update(entity);

            var subCat = new SubcategoryAttributeGroup
            {
                AttributeGroupId = model.Id,
                SubcategoryId = model.SubCategoryId

            };

            _context.SubcategoryAttributeGroups.Add(subCat);
            await _context.SaveChangesAsync();
           
        }
    }
}