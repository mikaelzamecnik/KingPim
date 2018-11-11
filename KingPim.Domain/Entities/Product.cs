using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Product
    {
        
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public int Version { get; set; }
        public bool PublishedStatus { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public IEnumerable<AttributeValue> AttributeValue { get; set; }
        

    }
}