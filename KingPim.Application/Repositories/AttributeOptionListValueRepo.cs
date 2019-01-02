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
    public class AttributeOptionListValueRepo : IAttributeOptionListValueRepo
    {
        public readonly KingPimDbContext _context;

        public AttributeOptionListValueRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All ProductAttributes
        public async Task<IEnumerable<AttributeOptionListValueModel>> GetAttributeOptionListValues()
        {
            
            return await _context.AttributeOptionListValues.Select(c =>
                new AttributeOptionListValueModel
                {
                    Id = c.Id,
                    ListValue = c.ListValue,
                    AttributeOptionListId = c.AttributeOptionListId
                }).ToListAsync();
        }

        // Get Single ProductAttribute
        public async Task<AttributeOptionListValueModel> GetAttributeOptionListValue(int id)
        {
            var entity = await _context.AttributeOptionListValues.FindAsync(id);

            if (entity == null)
                return null;

            return new AttributeOptionListValueModel
            {
                Id = entity.Id,
                ListValue = entity.ListValue,
                AttributeOptionListId = entity.AttributeOptionListId
            };
        }

        // Create new ProductAttributes
        public async Task CreateAttributeOptionListValue(AttributeOptionListValueModel model)
        {
            try
            {
                var entity = new AttributeOptionListValue
                {

                    Id = model.Id,
                    ListValue = model.ListValue,
                    AttributeOptionListId = model.AttributeOptionListId


                };
                _context.AttributeOptionListValues.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
