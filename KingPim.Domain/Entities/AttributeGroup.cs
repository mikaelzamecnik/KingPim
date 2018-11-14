using System;
using System.Collections.Generic;


namespace KingPim.Domain.Entities
{
    public class AttributeGroup : SystemValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SingleAttribute> SingleAttribute { get; set; }
        public ICollection<SubcategoryAttributeGroup> SubcategoryAttributeGroups {get;set;}
        
    }
}
