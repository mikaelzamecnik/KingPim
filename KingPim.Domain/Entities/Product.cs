using System;
using System.Collections.Generic;

namespace KingPim.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory {get;set;}
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public string Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}