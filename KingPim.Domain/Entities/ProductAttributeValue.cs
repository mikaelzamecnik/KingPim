using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class ProductAttributeValue
    {
        public string Value { get; set; }
        public virtual SingleAttribute SingleAttribute { get; set; }
        public int? SingleAttributeId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
    }
}
