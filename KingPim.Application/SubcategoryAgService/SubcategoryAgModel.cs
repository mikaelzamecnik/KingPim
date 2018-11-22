using KingPim.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.SubcategoryAgService
{
    public class SubcategoryAgModel
    {
        
        public int SubcategoryId { get; set; }
        public int AttributeGroupId { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<AttributeGroup> AttributeGroups { get; set; }
    }
}
