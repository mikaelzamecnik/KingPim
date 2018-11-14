using KingPim.Domain.Entities;
using System.Collections.Generic;

namespace KingPim.Application.SubCategoryService.Modify
{
    public class SubCategoryModifyCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
        public List<SubcategoryAttributeGroup> SubcategoryAttributeGroup { get; set; }
    }
}