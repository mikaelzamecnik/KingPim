using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class SubCategory: SystemValues
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }
        public ICollection<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }

    }
}
