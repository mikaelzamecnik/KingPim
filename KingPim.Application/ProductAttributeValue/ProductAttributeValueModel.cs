using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Application.ProductAttributeValue
{
    public class ProductAttributeValueModel
    {

        public int Id { get; set; }
        public string Value { get; set; }
        public int? SingleAttributeId { get; set; }
        public int? ProductId { get; set; }
        public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
        public IEnumerable<Domain.Entities.ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}
