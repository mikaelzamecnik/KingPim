using System;
using System.Collections.Generic;


namespace KingPim.Domain.Entities
{
    public class AttributeGroup : SystemValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<ProductAttribute> ProductAttribute { get; set; }

    }
}

