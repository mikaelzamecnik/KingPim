using System;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class AttributeType
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Key]
        public int SingleAttributeId { get; set; }
        public SingleAttribute SingleAttribute { get; set; }
        [Key]
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public string Value { get; set; }
    }
}
