using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeService.Get
{
    public class AttributeGetSingleModel
    {
        public int SingleAttributeId { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public IEnumerable<AttributeTypeValue> AttributeTypeValue { get; set; }
        public string Name { get; set; }
        // Enum values for diffrent input types ?
    }

}