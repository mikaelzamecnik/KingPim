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
    public class AttributeGroupRepo:IAttributeGroupRepo
    {
        public readonly KingPimDbContext _context;

        public AttributeGroupRepo(KingPimDbContext context)
        {
            _context = context;
        }


        // Get All AttributeGroups
        public async Task<IEnumerable<AttributeGroupModel>> GetAttributegroups()
        {
            return await _context.AttributeGroups.Select(c =>
                new AttributeGroupModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    DateCreated = c.DateCreated,
                    DateUpdated = c.DateUpdated,
                    PublishedStatus = c.PublishedStatus,
                    EditedBy = c.EditedBy,
                    Version = c.Version


                }).ToListAsync();
        }

        // Get Single AttributeGroup
        public async Task<AttributeGroupModel> GetAttributegroup(int id)
        {
            var entity = await _context.AttributeGroups.FindAsync(id);

            if (entity == null)
                return null;

            return new AttributeGroupModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                DateCreated = entity.DateCreated,
                DateUpdated = entity.DateUpdated,
                PublishedStatus = entity.PublishedStatus,
                EditedBy = entity.EditedBy,
                Version = entity.Version

            };
        }

        // Create new AttributeGroup
        public async Task CreateAttributegroup(AttributeGroupModel model)
        {
            try
            {
                var entity = new AttributeGroup
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreated = model.DateCreated,
                    EditedBy = model.EditedBy,
                    Version = model.Version,
                    PublishedStatus = model.PublishedStatus,

                };
                _context.AttributeGroups.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        // Update AttributeGroup
        public async Task UpdateAttributegroup(AttributeGroupModel model)
        {
            var entity = await _context.AttributeGroups.SingleAsync(c => c.Id == model.Id);
            {
                entity.Id = model.Id;
                entity.Name = model.Name;

                _context.AttributeGroups.Add(entity);

                await _context.SaveChangesAsync();
            }
        }

        // Delete AttributeGroup
        public async Task DeleteAttributegroup(int id)
        {
            var entity = await _context.AttributeGroups.SingleAsync(c => c.Id == id);
            _context.AttributeGroups.Remove(entity);

            await _context.SaveChangesAsync();

        }
    }
}
