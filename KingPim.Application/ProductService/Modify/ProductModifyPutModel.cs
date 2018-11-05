using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyPutModel
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
    }
}