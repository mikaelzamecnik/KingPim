using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class ProductAttributeValue
    {
        public string Value { get; set; }
        [Key]
        public int? SingleAttributeId { get; set; }
        public virtual Product Product { get; set; }
        [Key]
        public int? ProductId { get; set; }
    }
}
