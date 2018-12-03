using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KingPim.Application.Repositories.Models
{
    [Serializable]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public double Version { get; set; }
        public bool PublishedStatus { get; set; }
        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ProductAttribute ProductAttribute { get; set; }
        public virtual ICollection<ProductAttributeValue> ProductAttValues { get; set; }
        public List<Product> Products { get; set; }
        public ProductModel()
        {
            var valuelist = new ProductAttributeValue()
            {

            }
        }
    }
}
