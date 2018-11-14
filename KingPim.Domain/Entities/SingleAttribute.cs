using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class SingleAttribute: SystemValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
