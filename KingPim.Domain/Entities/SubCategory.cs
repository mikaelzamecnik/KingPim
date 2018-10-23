using System;
using System.Collections.Generic;

namespace KingPim.Domain.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category{get;set;}
        public string Name { get; set; }
    }
}
