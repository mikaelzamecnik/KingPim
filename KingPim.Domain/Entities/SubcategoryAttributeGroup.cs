using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class SubcategoryAttributeGroup
    {
        public int Id { get; set; }
        public int SubcategoryId { get; set; }
        public int AttributeGroupId { get; set; }
    }
}
