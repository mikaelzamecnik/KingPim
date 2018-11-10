using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}
