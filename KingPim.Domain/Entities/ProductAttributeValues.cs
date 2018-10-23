using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class ProductAttributesValues
    {
        [Key]
        public int ProductId { get; set; }
        [Key]
        public int AttributeId { get; set; }
        public string Value { get; set; }
    }
}
