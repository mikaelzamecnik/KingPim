﻿using KingPim.Application.Repositories.Interfaces;
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
        public async Task<IEnumerable<AttributeOptionListModel>> GetAttributeOptionList()
        {
            return await _context.AttributeOptionLists.Select(c =>
                new AttributeOptionListModel
                {
                    Id = c.Id,
                    ListValue = c.ListValue
                }).ToListAsync();
        }

        // Get Single ProductAttribute
        public async Task<AttributeOptionListModel> GetAttributeOptionValue(int id)
        {
            var entity = await _context.AttributeOptionLists.FindAsync(id);

            if (entity == null)
                return null;

            return new AttributeOptionListModel
            {
                Id = entity.Id,
                ListValue = entity.ListValue
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
                    ListValue = model.ListValue
                   

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
