using KingPim.Domain.Entities;
using System;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyPutModel
    {
        public int Id { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public string Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}