using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class AttributeOptionListValue
    {
        public int Id { get; set; }
        public string ListValue { get; set; }
        public int? AttributeOptionListId { get; set; }
        public virtual AttributeOptionList AttributeOptionList { get; set; }

    }
}
