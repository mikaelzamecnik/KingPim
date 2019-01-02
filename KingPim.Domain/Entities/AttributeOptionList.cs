using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class AttributeOptionList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }

    }
}
