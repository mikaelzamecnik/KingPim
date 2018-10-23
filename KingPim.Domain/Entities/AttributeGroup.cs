using System;
using System.Collections.Generic;


namespace KingPim.Domain.Entities
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory {get;set;}
        public string Name { get; set; }
    }
}
