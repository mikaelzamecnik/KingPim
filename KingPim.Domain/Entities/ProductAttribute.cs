using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class ProductAttribute: SystemValues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? AttributeGroupId { get; set; }
        public AttributeGroup AttributeGroup { get; set; }
        public int ProductAttributeValueId { get; set; }
        public ProductAttributeValue ProductAttributeValues {get;set;}
    }
}
