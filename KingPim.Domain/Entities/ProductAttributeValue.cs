using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class ProductAttributesValue
    {
        [Key]
        public int ProductID { get; set; }
        [Key]
        public int SingleAttributeId  { get; set; }
        public string Value { get; set; }
    }
}
