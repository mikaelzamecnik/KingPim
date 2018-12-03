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
        public int ProductAttributeId { get; set; }
        public int ProductId { get; set; }

    }
}
