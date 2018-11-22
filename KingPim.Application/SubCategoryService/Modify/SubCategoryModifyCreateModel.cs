using KingPim.Domain.Entities;
using System.Collections.Generic;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }
        public ICollection<AttributeGroup> AttributeGroups { get; } = new List<AttributeGroup>();
    }
}