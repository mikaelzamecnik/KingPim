using System;
using System.Collections.Generic;


namespace KingPim.Domain.Entities
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public IEnumerable<SingleAttribute> SingleAttribute { get; set; }
        
    }
}
