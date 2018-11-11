using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace KingPim.Application.AttributeService.Modify
{
    public class AttributeModifyCreateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public IEnumerable<AttributeValue> AttributeValues { get; set; }
        public AttValueEnum AttValueEnum { get; set; }

    }
}