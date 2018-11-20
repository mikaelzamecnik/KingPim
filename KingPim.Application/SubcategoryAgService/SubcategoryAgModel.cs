using KingPim.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.SubcategoryAgService
{
    public class SubcategoryAgModel
    {
        public SubCategory SubCategory { get; set; }
        public List<SelectListItem> AttributeGroups { get; set; }
        public int SubcategoryId { get; set; }
        public int AttributeGroupId { get; set; }

        public SubcategoryAgModel()
        {

        }

        public SubcategoryAgModel(SubCategory subcategory, IEnumerable<AttributeGroup> attributeGroups)
        {
            var AttributeGroups = new List<SelectListItem>();
            foreach (var item in attributeGroups)
            {
                AttributeGroups.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            SubCategory = subcategory;


        }
    }
}
