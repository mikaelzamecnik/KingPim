using KingPim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KingPim.Application.Repositories.Models
{
    public class ProductAttributeValuesModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int ProductAttributeId { get; set; }
        public int ProductId { get; set; }
        public virtual ProductAttribute ProductAttribute { get;set;}
        public virtual Product Product { get; set; }
    }
}
