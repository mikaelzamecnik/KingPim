using System;

namespace KingPim.Application.ProductService.Modify
{
    public class ProductModifyCreateModel
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public string Version { get; set; }
        public bool PublishedStatus { get; set; }
    }
}