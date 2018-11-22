using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class SubcategoryAttributeGroup
    {
        [Key]
        public int SubcategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        [Key]
        public int AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
    }
}
