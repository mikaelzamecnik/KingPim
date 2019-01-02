using KingPim.Application.Repositories.Interfaces;
using KingPim.Application.Repositories.Models;
using KingPim.Domain.Entities;
using KingPim.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPim.Application.Repositories
{
    public class AttributeOptionListRepo : IAttributeOptionListRepo
    {
        public readonly KingPimDbContext _context;

        public AttributeOptionListRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All ProductAttributes
        public async Task<IEnumerable<AttributeOptionListModel>> GetAttributeOptionLists()
        {
            return await _context.AttributeOptionLists.Select(c =>
                new AttributeOptionListModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        // Get Single ProductAttribute
        public async Task<AttributeOptionListModel> GetAttributeOptionList(int id)
        {
            var entity = await _context.AttributeOptionLists.FindAsync(id);

            if (entity == null)
                return null;

            return new AttributeOptionListModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        // Create new ProductAttributes
        public async Task CreateAttributeOptionList(AttributeOptionListModel model)
        {
            try
            {
                var entity = new AttributeOptionList
                {

                    Id = model.Id,
                    Name = model.Name

                };
                _context.AttributeOptionLists.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
