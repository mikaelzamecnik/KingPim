using System;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class AttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int SingleAttributeId { get; set; }
        public virtual SingleAttribute SingleAttribute { get; set; }
        public int ProductAttributeId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
