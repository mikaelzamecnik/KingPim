using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KingPim.Domain.Entities
{
    public class AttributeGroup : SystemValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<SubcategoryAttributeGroup> Subcategory { get; set; }
        public AttributeGroup()
        {
            Subcategory = new Collection<SubcategoryAttributeGroup>();
        }

    }
}

