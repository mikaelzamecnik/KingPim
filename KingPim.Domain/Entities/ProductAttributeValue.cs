using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPim.Domain.Entities
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual SingleAttribute SingleAttribute { get; set; }
        [ForeignKey("SingleAttribute")]
        public int? SingleAttributeId { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public int? ProductId { get; set; }
    }
}
