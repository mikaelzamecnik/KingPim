using System;
using System.Collections.Generic;

namespace KingPim.Domain.Entities
{
    public class SingleAttribute
    {
        public int Id { get; set; }
        public int AttributeGroupId { get; set; }
        public virtual AttributeGroup AttributeGroup {get;set;}
        public int AttributeTypeId { get; set; }
        public virtual AttributeType AttributeType {get;set;}
        public string Name { get; set; }
    }
}
