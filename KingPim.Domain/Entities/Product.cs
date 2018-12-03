using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Product: SystemValues
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
        public virtual List<ProductAttribute> ProductAttributes { get; set; }

    }
}