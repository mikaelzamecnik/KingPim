using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Product: SystemValues
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }


    }
}