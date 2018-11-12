using KingPim.Domain.Entities;
using KingPim.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.Catalog
{
    public class CatalogRepository: ICatalogRepository
    {
        private readonly KingPimDbContext ctx;

        public CatalogRepository(KingPimDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Category> Categories => ctx.Categories;
        public IEnumerable<SubCategory> SubCategories => ctx.SubCategories;
        public IEnumerable<Product> Products => ctx.Products;

    }
}
