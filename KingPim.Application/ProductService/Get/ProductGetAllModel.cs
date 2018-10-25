using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.ProductService.Get
{
public class ProductGetAllModel{

        public int Id { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string SubCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public string Version { get; set; }
        public bool PublishedStatus { get; set; }
}

}