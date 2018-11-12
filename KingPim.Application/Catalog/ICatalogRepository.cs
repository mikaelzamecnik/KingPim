using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.Catalog
{
    public interface ICatalogRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<SubCategory> SubCategories { get; }
        IEnumerable<Product> Products { get; }
    }
}
