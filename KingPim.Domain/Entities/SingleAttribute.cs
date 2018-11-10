using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class SingleAttribute
    {
        public int SingleAttributeId { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public IEnumerable<AttributeTypeValue> AttributeTypeValue { get; set; }
        public string Name { get; set; }
        // Enum values for diffrent input types ?
    }
}
