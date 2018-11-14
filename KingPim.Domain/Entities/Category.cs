using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KingPim.Domain.Entities
{
    public class Category: SystemValues
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
