using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.ProductService.Get
{
    public class ProductGetSingleModel
    {

        public int Id { get; set; }
        public SubCategory SubCategory { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public double Version { get; set; }
        public bool PublishedStatus { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }

}