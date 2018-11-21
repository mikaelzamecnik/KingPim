using KingPim.Domain.Entities;
using KingPim.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.SubcategoryAgService
{
    public class SubcategoryAgRepository : ISubcategoryAgRepository
    {
        private KingPimDbContext _context;
        public SubcategoryAgRepository(KingPimDbContext context)
        {
            _context = context;
        }


        public async Task JoinSCAG(SubcategoryAgModel model)
        {
            try
            {
                
                var scag = new SubcategoryAttributeGroup
                {
                    SubcategoryId = model.SubcategoryId,
                    AttributeGroupId = model.AttributeGroupId
                };

                _context.SubcategoryAttributeGroups.Add(scag);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

            
        }
    }
}

