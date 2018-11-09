using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeGroupService.Modify
{
    public class AgModifyCreateModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public IEnumerable<SingleAttribute> SingleAttribute { get; set; }

    }
}