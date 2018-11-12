using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PublishedStatus { get; set; }
        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
