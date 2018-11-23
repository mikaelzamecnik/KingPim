using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.Repositories.Models
{
    [Serializable]
    public class SubCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string EditedBy { get; set; }
        public double Version { get; set; }
        public bool PublishedStatus { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }
        public ICollection<AttributeGroup> AttributeGroups { get; } = new List<AttributeGroup>();
    }
}
