using KingPim.Domain.Entities;
using KingPim.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.SubcategoryAgService
{
    public class SubcategoryAgRepository : ISubcategoryAgRepository
    {
        private KingPimDbContext ctx;
        public SubcategoryAgRepository(KingPimDbContext context)
        {
            ctx = context;
        }

    }
}

